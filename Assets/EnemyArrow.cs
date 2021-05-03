using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class EnemyArrow : MonoBehaviour
{
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    public float destroyTimer = 1.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    public Rigidbody2D rb;
    public float speed = 5f;
    bool hit = false;
    //public float knockbackPower = 25;
    //public float knockbackDuration = 1;
    // bool hitButNotEnemy = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        Destroy(gameObject, destroyTimer); // zerst�rt Object nach ablauf der Zeit
        rb = this.GetComponent<Rigidbody2D>();
    }

    // hier wird der Schadenswert �bermittelt
    public void SetDamage(int amount)
    {
        damage = amount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hit)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Hero>().TakeDamage(damage);
                Destroy(gameObject);
                hit = true;
            }

            else if (other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
                hit = true;
                // hitButNotEnemy = true;
            }

            else
            {
                // hitButNotEnemy = true;
                // GetComponent<Collider>().enabled = false;
                // StartCoroutine(waitForSec(0.4f));

                // if (GetComponent<Collider>() != null)
                // {
                //     Debug.Log("Collider wurde nicht gefunden");
                // }
            }
        }
    }
    public void Setup(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(direction);
    }
}
