using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody2D))]

public class Arrow : MonoBehaviour
{
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    public float destroyTimer = 1.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll

    bool hit = false;
    bool hitButNotEnemy = false;

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
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
                hit = true;
            }

            else if (other.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
                hit = true;
            }

            else
            {
               // hitButNotEnemy = true;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}