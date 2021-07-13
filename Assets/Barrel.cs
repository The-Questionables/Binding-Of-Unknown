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
    public float detonationTimer = 0f;
    public GameObject Explosion;

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


            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }



            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);


        }
    }
}
