
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCoins : MonoBehaviour
{
    public AudioClip coinSound;
    // [Range(0, 1)] float heartSoundVolume = 1f;
    public int getCoins = 1;

    // Cached References
    GameManager gamemanager;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
         // AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position, heartSoundVolume);
            gamemanager.AddCoin(getCoins);

            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
