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
    // Slot
    //int relictSlots = 1; // hier noch automatiesieren


    // Cached References
    GameManager gamemanager;
    //Hero hero;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gamemanager.timeRewind == 0 && gamemanager.isRelictCollectable)
        {
            // AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position, heartSoundVolume);
            gamemanager.timeRewind += getTimeRewind;
            Debug.Log("Relict collected.");

            Destroy(gameObject);
        }
        if (collision.CompareTag("Player") && gamemanager.totem == 0 && gamemanager.isRelictCollectable)
        {
            // AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position, heartSoundVolume);
            gamemanager.totem += getTotem;
            Debug.Log("Relict collected.");

            Destroy(gameObject);
            if (gamemanager.timeRewind == 1)
            {
                //Instantiate(chestLootList[random], SpawnPoint.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            }
        }
        else
        {
            return;
        }
    }
}
