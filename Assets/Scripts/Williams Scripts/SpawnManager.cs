using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    public bool isPlayerInRoom = false;
    public bool isSpawnComplete = false;

    [Header("Intervals")] //Fügt Überschrift ein
    public float enemySpawnInterval; //Zeitraum zwischen den spawn der Gegner
    public float waveSpawnInterval; // Zeitraum zwischen den Wellen
    int currentWave; // Zeit wird hochgezählt während der Welle läuft

    int Gegner1ID = 0;
    int Gegner2ID = 0;
    int Gegner3ID = 0;

    [Header("Prefabs")]
    public GameObject Gegner1Prefab; //hier Einheit einsetzten
    public GameObject Gegner2Prefab;
    public GameObject Gegner3Prefab;


    [System.Serializable]
    public class Wave
    {

        public int Gegner1Amount; //Anzahl der Gegner die in der Welle Spawnen
        public int Gegner2Amount;
        public int Gegner3Amount;

    }
    [Header("Waves")]
    public List<Wave> waveList = new List<Wave>(); //Liste der Gegner

    [HideInInspector]
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    bool spawnComplete;

    void Start()
    {
        //Warten bevor starten des Spawnens beginnt
        //Invoke("StartSpawn", 1f); //Wartet 1 Sekunde
    }

    private void Update()
    {
        if (isPlayerInRoom && !isSpawnComplete)
        {
            Invoke("StartSpawn", 0.1f); //Wartet 1 Sekunde
            isSpawnComplete = true;
        }
    }

    IEnumerator SpawnWaves() // erstellen eine routine
    {
        while (currentWave < waveList.Count) //Prüfung wie viele Wellen noch bevorsthenen und bei welcher wir gerade sind
        {
            /*
            if(currentWave == waveList.Count-1)
            {
                spawnComplete = true;
            }
            */

            yield return new WaitForSeconds(enemySpawnInterval);
            // Spawn der Gegner
            for (int i = 0; i < waveList[currentWave].Gegner1Amount; i++)
            {
               // GameObject newGegner1 = Instantiate(Gegner1Prefab, new Vector2 (Gegner1Prefab.transform.position.x * transform.localScale.x, Gegner1Prefab.transform.position.z), Quaternion.Euler(6.06f, 0, 9.485115f));
                 GameObject newGegner1 = Instantiate(Gegner1Prefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                // Enemybehavior VirusBehavior = newGegner1.GetComponent<Enemybehavior>(); // auf Enemybehavior zugreifen und übertragen damit neu erstellter Virus weiß was er machen soll

                Gegner1ID++;



                spawnedEnemies.Add(newGegner1);

                //weitergeben an Game Manager
               // GameManager.instance.AddEnemy();

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }

            // Spawn des 2. Gegnertypen

            for (int i = 0; i < waveList[currentWave].Gegner2Amount; i++)
            {
                GameObject newGegner2 = Instantiate(Gegner2Prefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation

                Gegner2ID++;

                spawnedEnemies.Add(newGegner2);

                //weitergeben an Game Manager
                //GameManager.instance.AddEnemy();

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }
            // for (int i = 0; i < waveList[currentWave].Enemy2Amount; i++) ----------------- Weiß nicht mehr wozu das war


            // Spawn der Boss Schiffe
            for (int i = 0; i < waveList[currentWave].Gegner3Amount; i++)
            {
                GameObject newGegner3 = Instantiate(Gegner3Prefab, transform.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation

                Gegner3ID++;

                spawnedEnemies.Add(newGegner3);

                //weitergeben an Game Manager
                //GameManager.instance.AddEnemy();

                //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }




            yield return new WaitForSeconds(waveSpawnInterval);
            currentWave++; //Startet nächste Welle

        }
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnWaves());
        CancelInvoke("StartSpawn"); //fürs debuggen
    }
    //------------------------------------

    void OnValidate() //wird aktiviert wann immer eine nummer im Inspector verändert wird
                      // zählt alle Virus-Schiffe im Spiel zusammen
    {
        int GegnerAnzahl = 0;
        for (int i = 0; i < waveList.Count; i++)
        {
            GegnerAnzahl += waveList[i].Gegner1Amount;
            GegnerAnzahl += waveList[i].Gegner2Amount;
            GegnerAnzahl += waveList[i].Gegner3Amount;
        }
        /*
         if (curVirusAmount > 35)                                 //wenn mehr als 35 Feinde im Spiel sind entsteht Fehlermeldung
         {
             Debug.LogError("<color=red>Error!!</color> Your Virus amount is to high!" + curVirusAmount + "/ 35");
         }
       else
       { 
         Debug.Log("Current Total Virus: " + curVirusAmount);
       }
     }
     */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRoom = true;
        }
    }
    /*
    void ReportToGameManager()
    {
           if(spawnedEnemies.Count == 0 && spawnComplete)
       // if (spawnComplete)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.instance.WinCondition();
        }
    }

    public void UpdateSpawnedEnemies(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);

        ReportToGameManager();
    }
    */
}
