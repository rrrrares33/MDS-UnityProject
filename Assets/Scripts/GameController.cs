using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    // Current health of the character.
    private static int health = 5;
    // Maximum possible health of the character.
    private static int maxHealth = 5;
    // Damage dealt by the character.
    private static int damage = 1;
    // Movement speed of the character.
    private static float moveSpeed = 3;

    public static int Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static int Damage { get => damage; set => damage = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private static Text healthText;

    // Singleton type instance.
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
    }

    public static void DamagePlayer(int damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(int healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);
    }

    private static void KillPlayer()
    {

    }
}
