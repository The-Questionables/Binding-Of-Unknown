using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Arrow : MonoBehaviour
{

    public float destroyTimer = 1.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    public Rigidbody2D rb;
    public float speed= 5f;
    bool hit = false;
    public float knockbackPower = 25;
    public float knockbackDuration = 1;
    // bool hitButNotEnemy = false;

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //rb = GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit
        rb = this.GetComponent<Rigidbody2D>();
    }

    // hier wird der Schadenswert übermittelt
 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hit)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyStandart>().TakeDamage(gm.bowDamage);
                Destroy(gameObject);
                hit = true;
            }

            else if (other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
                hit = true;
                // hitButNotEnemy = true;
            }

            else if (other.gameObject.CompareTag("Barrel"))
            {
                other.gameObject.GetComponent<Barrel>().TakeDamage(gm.bowDamage);
                Destroy(gameObject);
                hit = true;
                // hitButNotEnemy = true;
            }

            else if (other.gameObject.CompareTag("Vase"))
            {
                other.gameObject.GetComponent<Vase>().TakeDamage(gm.bowDamage);
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