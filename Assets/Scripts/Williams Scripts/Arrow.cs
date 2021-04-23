using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Arrow : MonoBehaviour
{
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    public float destroyTimer = 1.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll

    bool hit = false;
    public float knockbackPower = 25;
    public float knockbackDuration = 1;
    // bool hitButNotEnemy = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit
    }

    // hier wird der Schadenswert übermittelt
    public void SetDamage(int amount)
    {
        damage = amount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hit)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
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
}