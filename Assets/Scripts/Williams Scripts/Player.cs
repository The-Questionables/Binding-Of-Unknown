using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 100;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    public float speed = 6f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public float detonationTimer = 0f;
    public GameObject Explosion;

    public Transform[] FireballSpawns;
    public GameObject Fireball;
    public double fireRateFireball = 1;
    public double nextFireFireBall = 1;
    int Fireballamount = 1; // Anzahl der Schüsse, später noch anpassbar
    int FireballDamage = 3; // Später noch anpassbar

    public GameObject crossHair;

    public Transform[] ArrowSpawns;
    public GameObject Arrow;
    public double fireRateArrow = 1;
    public double nextFireArrow = 1;
    int Arrowamount = 1; // Anzahl der Schüsse, später noch anpassbar
    int ArrowDamage = 3;

    // Start is called before the first frame update
    void Start()
    {
        // drehen des Projektile des Charakters in Blickrichtung 
        this.rb = this.GetComponent<Rigidbody2D>();
        this.rb.velocity = transform.right * speed * 10;
        transform.LookAt(transform.position, this.rb.velocity);

        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);

        currentMana = maxMana;          // verändet Wert der Manabar
        manaBar.SetMaxMana(maxMana);

    }

    // Update is called once per frame
    void Update()
    {
        //Char Movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
           // if (currentMana > 0)
          //  {
                ShootArrow();
          //  }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentMana > 0)
            {
                ShootFireball();
                Fireballcost(20); // hier kosten für den Zauber Fireball festlegen
            }
            //ShootFireball(10); //Kosten des Zaubers steht in Klammern
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    // void ShootFireball(int cost)
    void ShootFireball()
    {
        //Mana--;
      //  currentMana -= cost;
      //  ManaBar.SetMana(currentMana);

        nextFireFireBall = Time.time + fireRateFireball;
        for (int i = 0; i < Fireballamount; i++)
        {
            GameObject newFireball = Instantiate(Fireball, FireballSpawns[i].position, FireballSpawns[i].rotation) as GameObject;
            // Bringt der Rakete Schaden
            newFireball.GetComponent<Fireball>().SetDamage(FireballDamage);
        }
    }

    void ShootArrow()
    {
        //Mana--;
        //  currentMana -= cost;
        //  ManaBar.SetMana(currentMana);
        /*
        nextFireArrow = Time.time + fireRateArrow;
        for (int i = 0; i < Arrowamount; i++)
        {
            GameObject newArrow = Instantiate(Arrow, ArrowSpawns[i].position, ArrowSpawns[i].rotation) as GameObject;
            // Bringt der Rakete Schaden
            newArrow.GetComponent<Arrow>().SetDamage(ArrowDamage);
        }
        */
        nextFireArrow = Time.time + fireRateArrow;
        for (int i = 0; i < Arrowamount; i++)
        {
            GameObject newArrow = Instantiate(Arrow, transform.position, Quaternion.identity);
            newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(6.0f, 0.0f);
            // Bringt der Rakete Schaden
            newArrow.GetComponent<Arrow>().SetDamage(ArrowDamage);
        }
    }

        public void TakeDamage(int damage)
        {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
      if (currentHealth <= 0)
        {
            // Verliere Leben

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            /*
            // Erhöhe Punltzahl
            if (enemyState == EnemyStates.IDLE) //bedeutet in der Formation 
            {
                GameManager.instance.AddScore(Score);
            }
            else
            {
                GameManager.instance.AddScore(Score);
            }
            */

            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);
      }
        }

    void Fireballcost(int cost)
    {
        currentMana -= cost;

        manaBar.SetMana(currentMana);
    }

    /*
    public void RecoverHealth(int healthRecover) // wird aktiviert beim einsammeln von einen Heiltrank
    {
        currentHealth += healthRecover;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);
        UpdateHealthUI(playerCurrentHealth);
        //UpdateHealthUI();
    }
    */

    public void HealDamage(int healthRecover)
    {
        currentHealth += healthRecover;

        healthBar.SetHealth(currentHealth);
       
    }

    /*
    private void MoveCrossHair()
    {
        Vector3 aim = new Vector3(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"), 0.0f);

        if (aim.magnitude > 0.0f)
        {
            aim.Normalize();
            aim = aim * 0.4f;
            crossHair.transform.localPosition = aim;
            crossHair.SetActive(true);


        } else {
            crossHair.SetActive(false);
        }
    }
    */
}
