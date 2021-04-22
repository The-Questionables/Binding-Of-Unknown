
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLoot : MonoBehaviour
{
    public AudioClip heartSound;
    // [Range(0, 1)] float heartSoundVolume = 1f;
    public int healthRecover = 1;

    // Cached References
    Player playerController;

    private void Start()
    {
        playerController = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          //AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position, heartSoundVolume);
            playerController.HealDamage(healthRecover);
            Debug.Log("Heart used.");
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
