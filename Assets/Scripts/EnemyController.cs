using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wonder,
    Follow,
    Die
};

public class EnemyController : MonoBehaviour
{
    // Reference to the player
    GameObject player;
    public EnemyState currState = EnemyState.Wonder;
    // The range where enemy can see;
    [SerializeField] public float range;
    // Movement speed;
    [SerializeField] public float speed;
    // Pick a direction for wandering;
    private bool choseDir = false;
    private Vector3 randomDir;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch(currState)
        {
            case (EnemyState.Wonder):
                Wonder();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):
                break;
        }

        if (isPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if (!isPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Wonder;
        }
    }

    // Checks if player is in range or not.
    private bool isPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChoseDirection()
    {
        choseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, 0);
        choseDir = false;
    }

    void Wonder()
    {
        if (!choseDir)
        {
            StartCoroutine(ChoseDirection());
        }
        transform.position += -transform.right * speed * Time.deltaTime;
        if (isPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
