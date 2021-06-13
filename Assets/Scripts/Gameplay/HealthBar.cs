using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;

    public void LoseHealth(int value)
    {
        if (health <= 0)
            return;

        health = health - value;
        fillBar.fillAmount = health / 100;

        if(health<=0)
        {
            Debug.Log("YOU DIED");
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //    LoseHealth(25);
    }
}
