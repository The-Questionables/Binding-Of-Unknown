using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    public float detonationTimer = 0f;
    public GameObject Explosion;
   // public int health;
    public string Name;
    public int baseAttack;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // attackRadius);
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            // Verliere Leben

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
           // if (Explosion != null)
           // {
           //     Instantiate(Explosion, transform.position, Quaternion.identity);
           // }

            /*
            // Erhöhe Punltzahl
            if (enemyState == EnemyStates.IDLE) //bedeutet in der Formation 
            {
                GameManager.instance.AddScore(Score);
            }
            else
            {
                GameManager.instance.AddScore(Score);
            }
            */

            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);

        }
    }
}
