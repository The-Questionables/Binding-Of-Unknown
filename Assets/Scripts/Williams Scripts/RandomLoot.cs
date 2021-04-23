using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public GameObject[] LootList; // Array an Items
    private int random; // speichert kurz zufälligen Wert aus dem Array
    private bool lootSpawned = false; // sorgt dafür das Räume nicht gleichzeitig spawnen

    void Start()
    {
        //Invoke("Spawn", 0.2f); // aktiviert Methode mit einen Time delay
    }

    public void LootSpawn()
    {
        if (lootSpawned == false)
        {
            random = Random.Range(0, LootList.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus

            // Instantiate(LootList[UnityEngine.Random.Range(0, 6)], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            // Instantiate(templates.bottomRooms[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            Instantiate(LootList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
        }
        lootSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }
}