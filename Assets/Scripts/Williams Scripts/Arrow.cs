using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody2D))]

public class Arrow : MonoBehaviour
{

    // public GameObject player;
    //private Rigidbody2D rb;
    public int damage = 20; // hier einstellen wie hoch der Schaden sein soll den Gegner bekommen
    public float destroyTimer = 1.5f; // hier einstellen nach wie vielen Sekunden der Pfeil verschwinden soll
    // private float speed = 10f;
    // private Vector2 target;
    // private Vector2 position;
    bool hit = false;
   // public float knockbackPower = 100;
    //public float knockbackDuration = 1;

    void Start()
    {
        //  target = new Vector2(0.0f, 0.0f);
        //  position = gameObject.transform.position;
        //rb = GetComponent<Rigidbody2D>(); // greift auf den Rigidbody des Gameobjekts zu
        Destroy(gameObject, destroyTimer); // zerstört Object nach ablauf der Zeit

        //rb.velocity = new Vector2(speed, 0);
    }


    // Update is called once per frame
    void Update()
    {

    }
    /*
    float step = speed * Time.deltaTime;

  // move sprite towards the target location
  //  if (gameActive == true)
  //   {
  //     rb = !GetComponent<Rigidbody2D>();
  // rb = GetComponent<Rigidbody2D>(); delete
  // rb = transform.GetComponent<Rigidbody>().enabled = false;
  // Destroy(Rigidbody2D);
  //  }
  //Vector3.forward heißt Vorwärts in der Welt bewegen
  //transform.forward heißt bewegt das gameobject nach vorne
  //transform.Translate(transform.forward * Time.deltaTime * speed);
  //GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
  //GetComponent<Rigidbody2D>().AddForce(transform.up * speed * 3);
  //rb.velocity = transform.up * speed;
  //transform.Translate(transform.up * Time.deltaTime * speed);


    if (Input.GetKeyDown(KeyCode.W))
    {
        //transform.localRotation = new Quaternion(0f, 0f, 90f);

        //  GetComponent<Rigidbody2D>().velocity = new Vector3(speed, GetComponent<Rigidbody2D>().velocity.y);
        // transform.Translate(transform.up * Time.deltaTime * speed);
        // GetComponent<Rigidbody2D>().AddForce(transform.up * Time.deltaTime * speed);
        // moveSpeed = speed * transform.up;
        //rb.velocity = new Vector2(speed, rb.velocity.y); //transform.up * speed;
        //           rb.velocity = transform.up * speed;
        // rb.velocity = new Vector2(speed, 0);
        // GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * moveSpeed, 0);
       // GetComponent<Rigidbody2D>().velocity = new Vector2(1 * speed, 1);
        //fireballBody.velocity = new Vector2(speed, 0);
        // transform.position = Vector2.MoveTowards(transform.position, target, step);
        transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
    }

    if (Input.GetKeyDown(KeyCode.D)) //Rechts
    {
        //          rb.velocity = transform.right * -1 * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
    if (Input.GetKeyDown(KeyCode.A)) //Links
    {
        //          rb.velocity = transform.right * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, 0);
    }
    if (Input.GetKeyDown(KeyCode.S))
    {
        //          rb.velocity = transform.up * -1 * speed;
       // GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, -1);
        transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
    }

    // star.GetComponent<Rigidbody2D>().AddForce(transform.left * projectileSpeed);
    // transform.Translate(Vector3.forward * Time.deltaTime * speed);
}

*/
    // hier wird der Schadenswert übermittelt
    public void SetDamage(int amount)
    {
        damage = amount;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hit)
        {
            if (other.gameObject.tag == "Enemy")
            {
               // StartCoroutine(Enemy.instance.Knockback(knockbackDuration, knockbackPower, this.transform)); //Startet Coroutine Knockback für den Gegner
            }
            // ArrowStick(other);
            //rb.isKinematic = false;
            //rb.freezeRotation = true;
            //rb.destroy;
            Destroy(gameObject);
            hit = true;
            //Debug.Log("Hit");
        }
    }
    //void ArrowStick(Collision2D col)
    //{
        // move the arrow deep inside the enemy or whatever it sticks to
        // col.transform.Translate(depth * -Vector2.right);
        //  Make the arrow a child of the thing it's stuck to
        //  transform.parent = col.transform;     
        //  Destroy the arrow's rigidbody2D and collider2D
        //  Destroy(gameObject.rigidbody2D);
        //  Destroy(gameObject.collider2D);
    //}

    void OnTriggerEnter2D (Collider2D col)
    {

        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            //StartCoroutine(Enemy.instance.Knockback(knockbackDuration, knockbackPower, this.transform)); //Startet Coroutine Knockback für den Gegner
            Destroy(gameObject);
        }
    }
}