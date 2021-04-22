using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    [Header("Enemy Movement")]
    bool canMove = true;
    float freezeMovementTime = 1f;
    float freezeEnemyTime = 1f;
    private Color nativeColor;
    private Color freezeColor;
    private bool arrowFrozen;

     AudioClip damageSound;
     [Range(0, 1)] float damageSoundVolume = 1f;
     float enemyHealth = 1f;

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    // public Transform homePosition;
    public Rigidbody2D rb;
    public float detonationTimer = 0f;
    public GameObject Explosion;
   // public int health;
    public string Name;
    public int baseAttack;
    public float moveSpeed;
    // loot
    LootDrop lootDrop;

    public float knockbackPower = 25;
    public float knockbackDuration = 1;
    // General Cached References


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        this.rb = this.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        lootDrop = GetComponent<LootDrop>();

        nativeColor = GetComponentInChildren<SpriteRenderer>().color;
        freezeColor = Color.blue;

        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // attackRadius);
        }
    }
    public void TakeDamage(int amount)
    {
        if (damageSound != null)
        {
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, damageSoundVolume);
        }
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
             if (Explosion != null)
             {
                 Instantiate(Explosion, transform.position, Quaternion.identity);
             }

            // Dropt loot
            lootDrop.GetLootDrop(); // Führt GetLootDrop Methode vom LootDrop Script aus

            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !arrowFrozen)
        {
            target.GetComponent<Player>().TakeDamage(baseAttack);
            StartCoroutine(FreezeMovement());
        }
        else if (collision.CompareTag("Player")) //  (collision.gameObject.CompareTag("Player"))
        {
            target.GetComponent<Player>().TakeDamage(baseAttack);
          //  StartCoroutine(Player.instance.Knockback(knockbackDuration, knockbackPower, this.transform)); //Startet Coroutine Knockback für den Player buggy
        }
        else if (collision.CompareTag("MyWeapon")) //  
        {
            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            //  StartCoroutine(Player.instance.Knockback(knockbackDuration, knockbackPower, this.transform)); //Startet Coroutine Knockback für den Player buggy
        }
    }

    IEnumerator FreezeMovement()
    {
        canMove = false;

        yield return new WaitForSeconds(freezeMovementTime);

        canMove = true;
    }

    public void FreezeEnemy()
    {
        StartCoroutine(FreezeEnemyCoroutine());
    }

    IEnumerator FreezeEnemyCoroutine()
    {
        this.arrowFrozen = true;
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().enabled = false;
        }
        GetComponent<SpriteRenderer>().color = freezeColor;
        this.canMove = false;
        yield return new WaitForSeconds(freezeEnemyTime);
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().enabled = true;
        }
        this.canMove = true;
        GetComponent<SpriteRenderer>().color = nativeColor;
        this.arrowFrozen = false;
    }

    public bool CanEnemyMove()
    {
        return canMove;
    }

    public float GetEnemyHealth()
    {
        return enemyHealth;
    }

    // Buggy Knockback ***********************************************************************************
    
    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }
        yield return 0; // soll sofort passieren
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Player.instance.Knockback(knockbackDuration, knockbackPower, this.transform)); //Startet Coroutine Knockback für den Player
        }

    }
}
