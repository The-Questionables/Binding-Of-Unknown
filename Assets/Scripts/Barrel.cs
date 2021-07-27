using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public string Name;
    [Header("Enemy health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Enemy death")]
    //public float detonationTimer = 0f;
    public Animator Explosion;

    [Header("Enemy sounds")]
    AudioClip damageSound;
    [Range(0, 1)] float damageSoundVolume = 1f;

    [Header("References")]
    RandomLoot[] randomLoot;
    private int lengh_counter;

    // Start is called before the first frame update
    void Start()
    {
        randomLoot = GetComponents<RandomLoot>();
        currentHealth = maxHealth;          // verändet Wert der Healtbar
        lengh_counter = randomLoot.Length;
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
            // Spiele Effect ab
            if (Explosion != null)
            {
                Explosion.SetTrigger("die");
                // Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            if (randomLoot.Length <= 1) 
            { 
                randomLoot[0].LootSpawn();
            }
            else if(lengh_counter > 1)
            {
                while (lengh_counter >= 1)
                { 
                    randomLoot[lengh_counter - 1].LootSpawn();
                    lengh_counter--;
                }
            }

            //Destroy(gameObject, detonationTimer);
        }
    }
    public void DIE()
    {
        Destroy(gameObject);
    }
}
