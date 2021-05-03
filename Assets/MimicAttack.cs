using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicAttack : MonoBehaviour
{
    public bool isPlayerInRange;
    public Animator animator;
    bool isEnemy = false;

    public int maxHealth = 100;
    public int currentHealth;

    [Header("Enemy Movement")]
    bool canMove = true;


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
    // LootDrop lootDrop;
    RandomLoot randomLoot;
    // General Cached References

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        this.rb = this.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag(Slime_Const.Tag_Player).transform;
        //  lootDrop = GetComponent<LootDrop>();
        randomLoot = GetComponent<RandomLoot>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            // Spiele Angriffsanimation ab
            animator.SetBool("isMimic_Attack", true);
            isEnemy = true;
        }
        else
        {
            animator.SetBool("isMimic_Attack", false);
            animator.SetBool("isMimic_Idle", true);
        }
        CheckDistance();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
        if (other.CompareTag(Slime_Const.Tag_Player)) // Slime_Const.Tag_Player = Tag Player wird immer geändert
        {
            target.GetComponent<Hero>().TakeDamage(baseAttack);
        }
        else if (other.CompareTag(Slime_Const.Tag_Player)) //  (collision.gameObject.CompareTag(Slime_Const.Tag_Player))
        {
            target.GetComponent<Hero>().TakeDamage(baseAttack);
        }
        else if (other.CompareTag("MyWeapon") && isEnemy == true) //  Knockback für den Gegner wird hier aktiviert **************************************************
        {
            //Vector2 difference = transform.position - other.transform.position;
           // transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
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

        if (currentHealth <= 0)
        {

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // Dropt loot
            //  lootDrop.GetLootDrop(); // Führt GetLootDrop Methode vom LootDrop Script aus
            randomLoot.LootSpawn(); // Führt LootSpawn Methode vom RandomLoot Script aus


            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);
            //doorscript.KillsRequired--;
        }
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

