using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public bool isPlayerInRange;
    public bool isChestReadyToOpen;
    public bool isChestLootet;
    public bool isChest_Of_Everlasting_Wealth;
    public GameObject[] chestLootList; // Array an Items
    private int random; // speichert kurz zufälligen Wert aus dem Array
    private GameManager gm;

    // Spawnpoint 
    public Transform SpawnPoint;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (/*Input.GetKeyDown(KeyCode.Space) && */isPlayerInRange)
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        if (isChestReadyToOpen == true && isChestLootet == false && gm.chest_of_everlasting_wealth == false)
        {
            random = Random.Range(0, chestLootList.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus

            Instantiate(chestLootList[random], SpawnPoint.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            if (isChest_Of_Everlasting_Wealth == true)
            {
                gm.chest_of_everlasting_wealth = true;
            }
        }
        isChestReadyToOpen = true; // setzt bool auf true damit keine weiteren Items spawnen
        isChestLootet = true; // sorgt dafür das man die Truhe nicht 2 mal looten kann
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            isChestReadyToOpen = true;
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
            isChestReadyToOpen = false;
        }
    }
}
