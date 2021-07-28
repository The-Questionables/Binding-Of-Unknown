using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandart : MonoBehaviour
{
    GameManager gamemanager; // Verknüpfung mit Gamemanager

    [Header("Enemy Color")]
    private Color nativeColor;
    private Color damageColor;
    private float changeEnemyColor = 0.2f;

    //public float knockbackForce = 0.5f;

    public string Name;
    [Header("Enemy health")]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    [Header("Enemy Movement")]
    public float moveSpeed;

    [Header("Enemy attack")]
    public int baseAttack;

    [Header("Enemy death")]
    // public float detonationTimer = 0f;
    public bool isAnimated;
    public bool isEnemyDeath;
    public Animator Explosion;

    [Header("Enemy sounds")]
    AudioClip damageSound;
    [Range(0, 1)] float damageSoundVolume = 1f;

    [Header("References")]
    RandomLoot randomLoot;
    public Transform target;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Color
        nativeColor = GetComponent<SpriteRenderer>().color;
        damageColor = Color.red;

        gamemanager = FindObjectOfType<GameManager>();
        target = GameObject.FindGameObjectWithTag(Slime_Const.Tag_Player).transform;
        randomLoot = GetComponent<RandomLoot>();
        this.rb = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Slime_Const.Tag_Player)) // Slime_Const.Tag_Player = Tag Player wird immer geändert
        {
            target.GetComponent<Hero>().TakeDamage(baseAttack);
            // hier Coroutine zum erneuten Schlag aktivieren oder Knockback für Spieler ausführen

        }
        else if (collision.CompareTag("MyWeapon")) //  Knockback für den Gegner wird hier aktiviert **************************************************
        {
            // Funktioniert nicht
            //Vector2 difference = transform.position - collision.transform.position;
            //transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            // rigidbody.Addforce(new Vector2("x axis", "y axis")) // Verbuggt

            // Funktioniert nicht
            //Vector2 difference = (transform.position - collision.transform.position).normalized;
            //Vector2 force = difference * knockbackForce;
            //rb.AddForce(force, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange

            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x /4, transform.position.y + difference.y /4);
        }
        else if (collision.CompareTag("EnemyWeapon"))
        {
            // nothing
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

        // Color
        StartCoroutine(ChangeEnemyColorByHit());


        if (currentHealth <= 0)
        {
            isEnemyDeath = true;
            // Bewegung ausschalten
            moveSpeed = 0;

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Explosion.SetTrigger("die");
                // Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // Dropt loot
            //randomLoot.LootSpawn(); // Führt LootSpawn Methode vom RandomLoot Script aus

            // Zerstöre Gegner

            if (isAnimated == false)
            {
                Destroy(gameObject);
            }

            // Quest Kill Counter++
            gamemanager.Killcounter();
            //Debug.Log("Kill Bestätigt"); // bis hier hin funktioniert es
        }
    }

    IEnumerator ChangeEnemyColorByHit()
    {
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().enabled = false;
        }
        GetComponent<SpriteRenderer>().color = damageColor;

        yield return new WaitForSeconds(changeEnemyColor);
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().enabled = true;
        }
        GetComponent<SpriteRenderer>().color = nativeColor;
    }

    public void DIE()
    {
        Destroy(gameObject);
        randomLoot.LootSpawn(); // Führt LootSpawn Methode vom RandomLoot Script aus
    }
}
