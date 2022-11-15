Enemy health code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has perished!");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + " Damage Taken!");
    }
}

Enemy attack code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
 
        playerHealth.TakeDamage(damage);
        Debug.Log("Player Takes "+ damage + "points of damage");
        
    }
}

Player Health and take damage code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Debug.Log("Player Health = "+ currentHealth);

        if(currentHealth <= 0)
        {
            Debug.Log("You are dead! Game Over!");
            Time.timeScale = 0; // freeze game
        }
    }
    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
