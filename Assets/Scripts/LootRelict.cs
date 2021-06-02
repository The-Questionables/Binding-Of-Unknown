using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRelict : MonoBehaviour
{
    public AudioClip relictSound;
    // [Range(0, 1)] float relictSoundVolume = 1f;

    // Time Rewind Relict
    public int getTimeRewind = 1;

    // Totem
    public int getTotem = 1;

    // Relikte
    public GameObject timeRewind;
    public GameObject totem;

    // Cached References
    GameManager gamemanager;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gamemanager.timeRewind == 0 && gamemanager.totem == 0)
        {
            // AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position, heartSoundVolume);
            gamemanager.timeRewind += getTimeRewind;
            gamemanager.totem += getTotem;
            Debug.Log("Relict collected.");

            Destroy(gameObject);
        }
        
        // buggy *****************************************************************************************
        if (collision.CompareTag("Player") && gamemanager.totem == 1 && gamemanager.timeRewind == 0)
        {
            Destroy(gameObject);

            Instantiate(totem, transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            gamemanager.totem--;
        }
        else if (collision.CompareTag("Player") && gamemanager.totem == 0 && gamemanager.timeRewind == 1)
        {
            Destroy(gameObject);

            Instantiate(timeRewind, transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            gamemanager.timeRewind--;           
        }
        






        else
        {
            return;
        }
    }
}
