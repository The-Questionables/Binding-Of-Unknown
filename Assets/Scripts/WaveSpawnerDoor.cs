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
    private int random; // speichert kurz zufälligen Wert aus dem Array
    private bool chestSpawned; // sorgt dafür das Kisten nicht gleichzeitig spawnen

    private void Update()
    {
        if (KillsRequired == 0) // Wenn benötigte Kills bei 0 liegen, öffne die Tür
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
            random = Random.Range(0, chestList.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
            GameObject chest = Instantiate(chestList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
        }
        chestSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }

}
