using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCreator : MonoBehaviour
{

    public GameObject[] chestList; // Array an verschiedenen Kisten
    private int random; // speichert kurz zufälligen Wert aus dem Array
    private bool chestSpawned; // sorgt dafür das Kisten nicht gleichzeitig spawnen
    private float timer;
    public float spawntime = 3;
    public Transform SpawnPoint;

    private void Update()
    {
        if (timer >= spawntime)
        {
                Spawn();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void Spawn()
    {
        if (chestSpawned == false)
        {
            random = Random.Range(0, chestList.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
           // GameObject chest = Instantiate(chestList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            Instantiate(chestList[random], SpawnPoint.position, Quaternion.identity); // Clonen eines Objektes und erstellen
        }
        chestSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }
}

