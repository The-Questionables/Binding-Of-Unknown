using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyArrow : MonoBehaviour
{
    [Header("Projectile Damage")]
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    [Header("Projectile Duration")]
    public float destroyTimer = 0.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    [Header("Projectile Speed")]
    public float speed = 4f;

    void Start()
    {
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit
    }
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;// bewege Pfeil nach vorne
    }

    void OnTriggerEnter2D(Collider2D other)     // hier wird der Schaden übermittelt und das projektil zerstört wenn es auf den player trifft.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Hero>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class EnemyArrow : MonoBehaviour
{
    [Header("Projectile Damage")]
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    [Header("Projectile Duration")]
    public float destroyTimer = 1f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    [Header("Projectile Movement")]
    public float speed = 4f;
    [Header("Projectile Reference")]
    public Rigidbody2D rb;
    private bool hit = false;
    Transform targetPosition;
    Vector2 projectileDirection;
    //public float knockbackPower = 25;
    //public float knockbackDuration = 1;
    // bool hitButNotEnemy = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollowTargetPlayer();
    }

    private void FollowTargetPlayer()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        projectileDirection = new Vector2(targetPosition.position.x, targetPosition.position.y);
        transform.position = Vector2.MoveTowards(transform.position, projectileDirection, speed * Time.deltaTime);

        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        transform.LookAt(targetPosition.position, transform.up);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);
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
            }

            else
            {
                return;
            }
        }
    }
    public void Setup(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(direction);
    }
}
*/














/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class EnemyArrow : MonoBehaviour
{
    private bool timerStarted = true;

    [Header("Projectile Damage")]
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    [Header("Projectile Duration")]
    public float destroyTimer = 0.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    [Header("Projectile Movement")]
    public float speed = 4f;
    [Header("Projectile Reference")]
    public Rigidbody2D rb;
    private bool hit = false;
    Transform targetPosition;
    Vector2 projectileDirection;
    //public float knockbackPower = 25;
    //public float knockbackDuration = 1;
    // bool hitButNotEnemy = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (timerStarted == true) // neu hinzugefügt damit Spieler nicht verfolgt wird vom Pfeil
        {
            FollowTargetPlayer(); // soll nur am anfang aktiviert werden
        }

        transform.position = Vector2.MoveTowards(transform.position, projectileDirection, speed * Time.deltaTime); // bewege Pfeil nach vorne
    }

    private void FollowTargetPlayer()
    {

        // projectileDirection = new Vector2(targetPosition.transform.position.x - transform.position, targetPosition.transform.position.y - transform.position) speed * Time.deltaTime;

        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        projectileDirection = new Vector2(targetPosition.position.x, targetPosition.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, projectileDirection, speed * Time.deltaTime); // altes Bewegungsmuster

        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        transform.LookAt(targetPosition.position, transform.up);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);

        timerStarted = false;
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
            }

            else
            {
                return;
            }
        }
    }
    public void Setup(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(direction);
    }
}*/