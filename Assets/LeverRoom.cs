using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LeverRoom : MonoBehaviour
{
    public Tilemap map;

    public GameObject pressurePlate1;
    public GameObject pressurePlate2;
    public GameObject pressurePlate3;
    public GameObject pressurePlate4;

    public GameObject pressurePlate1Active;
    public GameObject pressurePlate2Active;
    public GameObject pressurePlate3Active;
    public GameObject pressurePlate4Active;

    public GameObject enemySpawner;

    public bool isPressurePlate1Pressd = false;
    public bool isPressurePlate2Pressd = false;
    public bool isPressurePlate3Pressd = false;
    public bool isPressurePlate4Pressd = false;

    public bool isCorrectPressurePlate1Pressd = false;
    public bool isCorrectPressurePlate2Pressd = false;
    public bool isCorrectPressurePlate3Pressd = false;
    public bool isCorrectPressurePlate4Pressd = false;

    public bool isCorrectOrder = false;
    public bool isRiddleComplete = false;
    public bool isResetComplete = false;

    // Spawner
    // Spawnpoint
    public Transform SpawnPoint;

    [Header("Intervals")] //Fügt Überschrift ein
    public float enemySpawnInterval; //Zeitraum zwischen den spawn der Gegner
    public float waveSpawnInterval; // Zeitraum zwischen den Wellen
    int currentWave; // Zeit wird hochgezählt während der Welle läuft

    int Gegner1ID = 0;

    [Header("Prefabs")]
    public GameObject Gegner1Prefab; //hier Einheit einsetzten
    public bool isSpawnComplete = false;


    [System.Serializable]
    public class Wave
    {
        public int Gegner1Amount; //Anzahl der Gegner die in der Welle Spawnen
    }

    [Header("Waves")]
    public List<Wave> waveList = new List<Wave>(); //Liste der Gegner

    [HideInInspector]
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    bool spawnComplete;

    IEnumerator SpawnWaves() // erstellen eine routine
    {
        while (currentWave < waveList.Count) //Prüfung wie viele Wellen noch bevorsthenen und bei welcher wir gerade sind
        {

            yield return new WaitForSeconds(enemySpawnInterval);
            // Spawn der Gegner
            for (int i = 0; i < waveList[currentWave].Gegner1Amount; i++)
            {
                GameObject newGegner1 = Instantiate(Gegner1Prefab, SpawnPoint.position, Quaternion.identity) as GameObject; //erstellen des neues Gameobjekt und rotation
                                                                                                                          
                Gegner1ID++;
                spawnedEnemies.Add(newGegner1);

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
        CancelInvoke("StartSpawn");
    }

    void OnValidate()
    {
        int GegnerAnzahl = 0;
        for (int i = 0; i < waveList.Count; i++)
        {
            GegnerAnzahl += waveList[i].Gegner1Amount;
        }
    }


    // Riddle
    private void Start()
    {
        pressurePlate1.GetComponent<BoxCollider2D>();
        pressurePlate2.GetComponent<BoxCollider2D>();
        pressurePlate3.GetComponent<BoxCollider2D>();
        pressurePlate4.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        PressurePlateCheck();

        if (isRiddleComplete == true)
        {
            DoorOpener();
        }
        else 
        {
            DoorLock();
        }
    }

    public void CorrectOrderCheck()
    {
        if (isCorrectPressurePlate1Pressd == true)
        {
            isResetComplete = false;
            isCorrectOrder = true;
            if (isCorrectPressurePlate2Pressd == true)
            {
                isCorrectOrder = true;
                if (isCorrectPressurePlate3Pressd == true)
                {
                    isCorrectOrder = true;
                    if (isCorrectPressurePlate4Pressd == true)
                    {
                        isCorrectOrder = true;
                        isRiddleComplete = true;
                    }
                    else if (!isResetComplete)
                    {
                        ResetPressurePlate();
                        isResetComplete = true;
                    }
                }
                else if (!isResetComplete)
                {
                    ResetPressurePlate();
                    isResetComplete = true;
                }
            }
            else if (!isResetComplete)
            {
                ResetPressurePlate();
                isResetComplete = true;
            }
        }
        else if (!isResetComplete)
        {
            ResetPressurePlate();
            isResetComplete = true;
        }


    }

    public void PressurePlateCheck()
    {
        if(isPressurePlate1Pressd || isPressurePlate2Pressd || isPressurePlate3Pressd || isPressurePlate4Pressd)
        {
            CorrectOrderCheck();
        }

        if (isPressurePlate1Pressd == true && isCorrectOrder == true) // Richtige Reihnfolge wurde 1 platte richtig gedrückt )
        {
            pressurePlate1.SetActive(false);
            pressurePlate1Active.SetActive(true);
        }

        if (isPressurePlate2Pressd == true && isCorrectOrder == true)
        {
            pressurePlate2.SetActive(false);
            pressurePlate2Active.SetActive(true);
        }

        if (isPressurePlate3Pressd == true && isCorrectOrder == true)
        {
            pressurePlate3.SetActive(false);
            pressurePlate3Active.SetActive(true);
        }

        if (isPressurePlate4Pressd == true && isCorrectOrder == true) //isCorrectPressurePlate4Pressd == true)
        {
            pressurePlate4.SetActive(false);
            pressurePlate4Active.SetActive(true);
        }
    }

    public void ResetPressurePlate()
    {
        isCorrectOrder = false;
        pressurePlate1.SetActive(true);
        pressurePlate1Active.SetActive(false);
      //isPressurePlate1Pressd = false;
      //  isCorrectPressurePlate1Pressd = false;

        pressurePlate2.SetActive(true);
        pressurePlate2Active.SetActive(false);
      //isPressurePlate2Pressd = false;
       // isCorrectPressurePlate2Pressd = false;

        pressurePlate3.SetActive(true);
        pressurePlate3Active.SetActive(false);
        //isPressurePlate3Pressd = false;
       //isCorrectPressurePlate3Pressd = false;

        pressurePlate4.SetActive(true);
        pressurePlate4Active.SetActive(false);
        //isPressurePlate4Pressd = false;
        //isCorrectPressurePlate4Pressd = false;



        // Spawm Enemys
        if (!isSpawnComplete)
        {
            Invoke("StartSpawn", 0.1f); //Wartet 1 Sekunde
            isSpawnComplete = true;
        }
    }
    private void DoorOpener()
    {
        GetComponent<TilemapRenderer>().enabled = false;
        GetComponent<TilemapCollider2D>().enabled = false;
    }

    private void DoorLock()
    {
        GetComponent<TilemapRenderer>().enabled = true;
        GetComponent<TilemapCollider2D>().enabled = true;
    }
}

