using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody2D))]

public class Arrow : MonoBehaviour
{

   // public GameObject player;
    //private Rigidbody2D rb;
    public int damage = 30;
   // private float speed = 10f;
   // private Vector2 target;
   // private Vector2 position;


    void Start()
    {
      //  target = new Vector2(0.0f, 0.0f);
      //  position = gameObject.transform.position;
      //  rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
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
    // verbunden mit Enemybehavior zeile 100
    public void SetDamage(int amount)
    {
        damage = amount;
    }

     void OnTriggerEnter2D (Collider2D col)
    //private void OnTriggerEnter2D(Collider2D col) funktioniert nicht
   // private void OnTriggerStay2D(Collider2D col)
     {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }

     }

}