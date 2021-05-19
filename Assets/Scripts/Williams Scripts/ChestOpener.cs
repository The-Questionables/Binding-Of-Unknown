using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public bool isPlayerInRange;
    public bool isCheastReadyToOpen;
    public bool isCheastLootet;

    public GameObject[] chestLootList; // Array an Items
    private int random; // speichert kurz zufälligen Wert aus dem Array

    // Spawnpoint
    public Transform SpawnPoint;

    void Update()
    {
        if (/*Input.GetKeyDown(KeyCode.Space) && */isPlayerInRange)
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        if (isCheastReadyToOpen == true && isCheastLootet == false)
        {
            random = Random.Range(0, chestLootList.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus

            Instantiate(chestLootList[random], SpawnPoint.position, Quaternion.identity); // Clonen eines Objektes und erstellen
         // Instantiate(chestLootList[random], new Vector3(0, 0, 1.0f), Quaternion.identity); // Clonen eines Objektes und erstellen
         // Instantiate(chestLootList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
        }
        isCheastReadyToOpen = true; // setzt bool auf true damit keine weiteren Items spawnen
        isCheastLootet = true; // sorgt dafür das man die Truhe nicht 2 mal looten kann
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            isCheastReadyToOpen = true;
        }

        if (other.CompareTag("Relict"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            isCheastReadyToOpen = false;
        }
    }
}
