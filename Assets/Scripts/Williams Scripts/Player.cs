using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int maxHealth = 100;
    public int currentHealth;

    public int healpots;

    public HealthBar healthBar;

    public float speed = 5f;
    public Animator playerAnimator;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;

    public float detonationTimer = 0f;
    public GameObject Explosion;

    public GameObject crossHair;

    public float knockbackPower = 25;
    public float knockbackDuration = 1;
   // private Color nativeColor;
   // private bool inRecovery;
   // private float recoveryCounter = 0f;
    public float playerRecoveryTime = 1f;
    public int healthRecover = 10;
    public int useHealpotions = 1;
    GameManager gamemanager;

    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        instance = this;
        // drehen des Projektile des Charakters in Blickrichtung 
        this.rb = this.GetComponent<Rigidbody2D>();
        this.rb.velocity = transform.right * speed * 10;
        //transform.LookAt(transform.position, this.rb.velocity);

        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
        {
            //Char Movement
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

           // animator.SetFloat("Horizontal", movement.x);
          //  animator.SetFloat("Vertical", movement.y);
           // animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }

            if (Input.GetKeyDown(KeyCode.Q) && gamemanager.healpotions > 0 && currentHealth != maxHealth) // Gamemanager fragen wie viele heiltränke wir haben, wemm über 1 = true, wenn Leben Voll = false
            {
                HealDamage(healthRecover);
            }
    }

    /*
    private void SetRecoveryTime()
    {
        if (inRecovery)
        {
            GetComponent<SpriteRenderer>().color = Color.green;

            recoveryCounter += Time.deltaTime;

            if (recoveryCounter >= playerRecoveryTime)
            {
                inRecovery = false;
                recoveryCounter = 0;
                GetComponent<SpriteRenderer>().color = nativeColor;
            }
        }
    }
    */

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

     public void TakeDamage(int damage)
     {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);
        }
     }

    public void HealDamage(int healthRecover)
    {
        currentHealth += healthRecover;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth; 
        }

        healthBar.SetHealth(currentHealth);
        gamemanager.UseHealpotions(useHealpotions);
        
    }
}
