using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    [Header("Enemy Movement")]
    public float enemyMoveSpeed = 1f;
    public float safetyDistance = 1f;
    public float retreatDistance = 1f;
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
    [Header("Enemy Projectile Damage")]
    //AudioClip projectileSound;
    //[Range(0, 1)] float projectileSoundVolume = 1f;
    public GameObject enemyProjectilePrefab;
    float cooldownDuration = 1f;

    [Header("Enemy Projectile Damage")]
    public float cooldownTimer = 1f;
    private bool canShoot = true;
    //private bool insideCamera = false;
    // General Cached References
    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {

        gameCamera = Camera.main;
        this.rb = this.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag(Slime_Const.Tag_Player).transform;
        //  lootDrop = GetComponent<LootDrop>();
        randomLoot = GetComponent<RandomLoot>();

        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        ControllEnemyMovementAndShooting();

        HandleShootingCooldownTime();
    }

    private void ControllEnemyMovementAndShooting()
    {

        if (target && canMove)
        {
            if (transform.position.y > 4.5)
            {
                Vector2 newPosition = new Vector2(transform.position.x, 4.5f);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (transform.position.y < -4.5)
            {
                Vector2 newPosition = new Vector2(transform.position.x, -4.5f);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (transform.position.x > 8.5)
            {
                Vector2 newPosition = new Vector2(8.5f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (transform.position.x < -8.5)
            {
                Vector2 newPosition = new Vector2(-8.5f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (Vector2.Distance(transform.position, target.position) > safetyDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemyMoveSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < safetyDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
            {
                transform.position = this.transform.position;

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
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
            randomLoot.LootSpawn(); // Führt LootSpawn Methode vom RandomLoot Script aus

            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Slime_Const.Tag_Player)) // Slime_Const.Tag_Player = Tag Player wird immer geändert
        {
            target.GetComponent<Hero>().TakeDamage(baseAttack);
            // hier Coroutine zum erneuten Schlag aktivieren
        }
        else if (collision.CompareTag("MyWeapon")) //  Knockback für den Gegner wird hier aktiviert **************************************************
        {
            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
        //else if (collision.CompareTag("EnemyWeapon"))
       // {
            // nothing
        //}
    }


    public bool CanEnemyMove()
    {
        return canMove;
    }

    public float GetEnemyHealth()
    {
        return enemyHealth;
    }

    private void HandleShootingCooldownTime()
    {
        if (cooldownTimer <= 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void ShootProjectile()
    {
        if (canMove)
        {
          //  AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
            GameObject newProjectile = Instantiate(enemyProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            cooldownTimer = cooldownDuration;
        }
    }
}
