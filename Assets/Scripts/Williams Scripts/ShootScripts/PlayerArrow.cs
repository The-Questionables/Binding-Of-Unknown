using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    public float destroyTimer = 1.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    public Rigidbody2D rb;
    bool hit = false;

    // Knockback test
    //public float thrust = 1f;
    //public float knockTime = 0.01f;
    private GameManager gm;
    void Start()
    {
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit
        rb = this.GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        gm = FindObjectOfType<GameManager>();

    }

 /*   // hier wird der Schadenswert übermittelt
    public void SetDamage(int amount)
    {
        damage = amount;
    }
*/ //nope wird er nicht

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hit)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyStandart>().TakeDamage(gm.bowDamage);
                Destroy(gameObject);
                hit = true;
                /*
                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                if(enemy != null)
                {
                    //enemy.isKinematic = false;
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(KnockCo(enemy));
                }
                */
            }

            else if (other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
                hit = true;
                // hitButNotEnemy = true;
            }

            else
            {

            }
        }
    }
    /*
    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            //enemy.velocity = Vector2.zero;
            //enemy.isKinematic = true;
        }
    }
    */
}
