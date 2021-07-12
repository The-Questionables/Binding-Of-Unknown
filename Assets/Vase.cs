using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public string Name;
    [Header("Enemy health")]
    public int maxHealth = 20;
    public int currentHealth;

    [Header("Enemy death")]
    public float detonationTimer = 1f;
    public Animator Explosion;

    [Header("Enemy sounds")]
    AudioClip damageSound;
    [Range(0, 1)] float damageSoundVolume = 1f;

    [Header("References")]
    RandomLoot randomLoot;

    // Start is called before the first frame update
    void Start()
    {
        randomLoot = GetComponent<RandomLoot>();
        currentHealth = maxHealth;          // verändet Wert der Healtbar
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
                Explosion.SetTrigger("die");
                //Instantiate(Explosion, transform.position, Quaternion.identity);
            }
            //Explosion.SetBool("Dead", true);
            //Explosion.SetTrigger("Broken");
            // Dropt loot
            //randomLoot.LootSpawn(); // Führt LootSpawn Methode vom RandomLoot Script aus

            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);

            // Quest Kill Counter++
            //gamemanager.Killcounter();
            //Debug.Log("Kill Bestätigt"); // bis hier hin funktioniert es
        }
    }
}