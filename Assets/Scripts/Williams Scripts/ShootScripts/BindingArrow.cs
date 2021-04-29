using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindingArrow : MonoBehaviour
{
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    public float destroyTimer = 1.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    public Rigidbody2D rb;
    bool hit = false;
    // bool hitButNotEnemy = false;

    void Start()
    {
        // GetMouseButton
        // else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        // rb = GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        // if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit
        rb = this.GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 45);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 135);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, -45);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, -90);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, -135);
        }
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
