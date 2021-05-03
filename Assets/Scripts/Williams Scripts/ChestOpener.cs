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

            // Instantiate(LootList[UnityEngine.Random.Range(0, 6)], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            // Instantiate(templates.bottomRooms[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            Instantiate(chestLootList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
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
