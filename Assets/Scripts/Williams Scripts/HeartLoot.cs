
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLoot : MonoBehaviour
{
    public AudioClip heartSound;
    // [Range(0, 1)] float heartSoundVolume = 1f;
    public int getHealpotions = 1;

    // Cached References
    GameManager gamemanager;

    private void Start()
    {
        //playerController = FindObjectOfType<Player>();
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position, heartSoundVolume);
            //playerController.HealDamage(healthRecover);
            ////////////////////////////////////////////////////gamemanager.HealDamage(healthRecover);*********************************** Heilfunktion einbauen und übertragen auf gamemanager
            gamemanager.AddHealpotions(getHealpotions);
            Debug.Log("Heart collect.");
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
