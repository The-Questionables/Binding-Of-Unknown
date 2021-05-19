using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [Header("Rooms:")]
    // Erstellen von Arrays für die Räume
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom; // gespeicherter Raum zum schließen von Öffnungen
    public List<GameObject> rooms; // Liste an Räumen


    private float randomXposition;
    private float randomYposition;
    private Vector3 randomSpawnPosition;

    private int random; // speichert zufälligen Wert aus dem Array

    [Header("Range Enemys:")]
    public GameObject rangeEnemys; // Prefab FernkampfGegnern
    public int rangeEnemyAmount;
    private bool spawnedRangeEnemys;
    private int rangeEnemyAmountCounter = 0;

    [Header("Melee Enemys:")]
    public GameObject hellebardeEnemys; // Prefab NahkampfGegnern
    public int hellebardeEnemyAmount;
    private bool spawnedHellebardeEnemys;
    private int hellebardeEnemyAmountCounter = 0;

    [Header("Relict Spawner:")]
    public GameObject relictSpawner; // Prefab RelictSpawner
    public int relictSpawnerAmount;
    private bool spawnedRelictSpawnSpawner;
    private int relictSpawnerAmountCounter = 0;

    private float waitTime = 5f;

    [Header("Boss oder Treppe Spawner:")]
    private bool spawnedBoss;
    public GameObject boss; // boss oder Treppe

    // Update is called once per frame
    void Update()
    {
        SpawnBossOderTreppe();
        SpawnRangeEnemys();
        SpawnHellebardeEnemys();
        RelictSpawnSpawner();
    }

    // für jeden Gegner soll eine zufällige Position ausgesucht werden und gespawnt werden
    public void SpawnRangeEnemys()
    {
        if(waitTime <= 0 && spawnedRangeEnemys == false)
        {
                // für jeden Gegner wird for loop einmal ausgeführt
            for (int i = 0; i < rangeEnemyAmount; i++)
              {
                // wählt einen zufälligen RaumZahlenWert zum Spawnen aus
                random = Random.Range(0, rooms.Count - 1); // -1 Damit Gegner nicht im Boss Raum gespawnt werden

                // Spawnt Enemys in der Mitte eines zufällig ausgewählten Raumes
                // Instantiate(rangeEnemys, rooms[random].transform.position, Quaternion.identity); 

                // Zufälliger Ort in einen Raum
                randomXposition = Random.Range(-6f, 6f);
                randomYposition = Random.Range(-3f, 2f);
                randomSpawnPosition = new Vector3(randomXposition, randomYposition, 0f);
                //Instantiate(rangeEnemys, randomSpawnPosition, Quaternion.identity);

                // Zufälliger Ort in einen zufälligen Raum
                Instantiate(rangeEnemys, randomSpawnPosition + rooms[random].transform.position, Quaternion.identity); 
                rangeEnemyAmountCounter++;
            }

            if (rangeEnemyAmountCounter == rangeEnemyAmount)
            {
                spawnedRangeEnemys = true;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void SpawnHellebardeEnemys()
    {
        if (waitTime <= 0 && spawnedHellebardeEnemys == false)
        {
            // für jeden Gegner wird for loop einmal ausgeführt
            for (int i = 0; i < hellebardeEnemyAmount; i++)
            {
                // wählt einen zufälligen RaumZahlenWert zum Spawnen aus
                random = Random.Range(0, rooms.Count - 1); // -1 Damit Gegner nicht im Boss Raum gespawnt werden

                // Spawnt Enemys in der Mitte eines zufällig ausgewählten Raumes
                // Instantiate(rangeEnemys, rooms[random].transform.position, Quaternion.identity); 

                // Zufälliger Ort in einen Raum
                randomXposition = Random.Range(-6f, 6f);
                randomYposition = Random.Range(-3f, 2f);
                randomSpawnPosition = new Vector3(randomXposition, randomYposition, 0f);
                //Instantiate(rangeEnemys, randomSpawnPosition, Quaternion.identity);

                // Zufälliger Ort in einen zufälligen Raum
                Instantiate(hellebardeEnemys, randomSpawnPosition + rooms[random].transform.position, Quaternion.identity);
                hellebardeEnemyAmountCounter++;
            }

            if (hellebardeEnemyAmountCounter == hellebardeEnemyAmount)
            {
                spawnedHellebardeEnemys = true;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void SpawnBossOderTreppe()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            /*
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count-1) // Listen starten mit einen Index von 0
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                }
            }
            */
            Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            spawnedBoss = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void RelictSpawnSpawner()
    {
        if (waitTime <= 0 && spawnedRelictSpawnSpawner == false)
        {
            // für jedes Relikt wird der for loop einmal ausgeführt
            for (int i = 0; i < relictSpawnerAmount; i++)
            {
                // wählt einen zufälligen RaumZahlenWert zum Spawnen aus
                random = Random.Range(0, rooms.Count - 1); // -1 Damit Gegner nicht im Boss Raum gespawnt werden
                Instantiate(relictSpawner, rooms[random].transform.position, Quaternion.identity); // Spawnt Enemys in der Mitte eines zufällig ausgewählten Raumes
                relictSpawnerAmountCounter++;
            }
            if (relictSpawnerAmountCounter == relictSpawnerAmount)
            {
                spawnedRelictSpawnSpawner = true;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    
}
