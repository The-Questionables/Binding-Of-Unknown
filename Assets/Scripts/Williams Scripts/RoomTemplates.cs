using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    // Erstellen von Arrays für die Räume
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom; // gespeicherter Raum zum schließen von Öffnungen

    public List<GameObject> rooms; // Liste an Räumen


    private int random; // speichert zufälligen Wert aus dem Array
    public GameObject rangeEnemys; // Liste an FernkampfGegnern
    public int rangeEnemyAmount;
    private bool spawnedRangeEnemys;
    private int rangeEnemyAmountCounter = 0;

    public GameObject hellebardeEnemys; // Liste an NahkampfGegnern
    public int hellebardeEnemysAmount;
    private bool spawnedHellebardeEnemys;

    public float waitTime = 5f;
    private bool spawnedBoss;
    public GameObject boss; // boss oder Treppe


    // Update is called once per frame
    void Update()
    {
        SpawnBossOderTreppe();
        SpawnRangeEnemys();
    }

    public void SpawnRangeEnemys()
    {
        if(waitTime <= 0 && spawnedRangeEnemys == false)
        {
                //  random = Random.Range(0, templates.rightRooms.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
                //  Instantiate(templates.rightRooms[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen

                // wählt einen zufälligen RaumZahlenWert zum Spawnen aus
                // für jeden Gegner soll eine zufällige Position ausgesucht werden und gespawnt werden
           
                // Spawn der Gegner
                for (int i = 0; i < rangeEnemyAmount; i++)
                {
                    random = Random.Range(0, rooms.Count);
                    Instantiate(rangeEnemys, rooms[random].transform.position, Quaternion.identity); // Spawnt Enemy am zufällig ausgewählten Raum
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
}
