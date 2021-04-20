using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    public float detonationTimer = 0f;
    public GameObject Explosion;
   // public int health;
    public string Name;
    public int baseAttack;
    public float moveSpeed;
    // loot
    LootDrop lootDrop;
    // General Cached References


    // Start is called before the first frame update
    void Start()
    {
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
        else if (collision.CompareTag("Player"))
        {
            target.GetComponent<Player>().TakeDamage(baseAttack);
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
}
