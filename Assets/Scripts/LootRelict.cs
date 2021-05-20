using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRelict : MonoBehaviour
{
    public AudioClip relictSound;
    // [Range(0, 1)] float relictSoundVolume = 1f;

    public int getTimeRewind = 1;
    int relictSlots = 1; // hier noch automatiesieren

    // Cached References
    GameManager gamemanager;
    //Hero hero;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )//&& gamemanager.isRelictCollectable)
        {
            // AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position, heartSoundVolume);
            gamemanager.timeRewind += getTimeRewind;
            Debug.Log("Relict collected.");

            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
