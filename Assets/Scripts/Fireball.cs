using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody2D))]


public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    public int damage = 30;
    private float speed = 5f; // geschwindigkeit der Schüsse, später noch anpassbar (muss man erst mal testen)

    // zerstöre Feuerball nach 10 Sekunden
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }


    // Update is called once per frame
    void Update()
    {
        //Vector3.forward heißt Vorwärts in der Welt bewegen
        //transform.forward heißt bewegt das gameobject nach vorne
        // transform.Translate(transform.forward * Time.deltaTime * speed);
        // GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
        //GetComponent<Rigidbody2D>().AddForce(transform.up * speed * 2);
        // GetComponent<Rigidbody2D>().AddForce(transform.forward * speed * 3);
        rb.velocity = transform.up * speed;
        // star.GetComponent<Rigidbody2D>().AddForce(transform.left * projectileSpeed);
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    // verbunden mit Enemybehavior zeile 100
    public void SetDamage(int amount)
    {
        damage = amount;
    }

  //void OnTriggerEnter(Collider col)
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }

        //Danach zerstöre Geschoss
     //   Destroy(gameObject);


    }

}