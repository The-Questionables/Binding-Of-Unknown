using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveSpawnerDoor : MonoBehaviour
{
    public Tilemap map;
    [SerializeField]
    private int KillsRequired = 4;
    private bool isEnemyInRoom = true;

    public GameObject[] chestList; // Array an verschiedenen Kisten
    private int random; // speichert kurz zuf�lligen Wert aus dem Array
    private bool chestSpawned; // sorgt daf�r das Kisten nicht gleichzeitig spawnen

    private void Update()
    {
        if (KillsRequired == 0) // Wenn ben�tigte Kills bei 0 liegen, �ffne die T�r
        {
            isEnemyInRoom = false;
            //KillsRequired = 0;
        }
        else if (KillsRequired > 0)
        {
            DoorLock();
        }
        if(isEnemyInRoom == false)
        {
            DoorOpener();
        }
    }

    private void DoorOpener()
    {
        GetComponent<TilemapRenderer>().enabled = false;
        GetComponent<TilemapCollider2D>().enabled = false;
        SpawnChest();
    }

    private void DoorLock()
    {
        GetComponent<TilemapRenderer>().enabled = true;
        GetComponent<TilemapCollider2D>().enabled = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            KillsRequired--;
        }
    }

    public void SpawnChest()
    {
        if (chestSpawned == false)
        {
            random = Random.Range(0, chestList.Length); // Sucht zuf�lligen L�ngenwert des BottomRoom Arrays aus
            GameObject chest = Instantiate(chestList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
        }
        chestSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }

}
