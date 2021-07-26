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

    public bool isPressurePlate1Pressd = false;
    public bool isPressurePlate2Pressd = false;
    public bool isPressurePlate3Pressd = false;
    public bool isPressurePlate4Pressd = false;

    public bool isCorrectOrder = false;
    public bool isRiddleComplete = false;
    public bool isResetComplete = false;

    // Spawner
    public Transform spawnPoint;
    public GameObject[] enemyList; // Array an Gegnern
    public bool isSpawnComplete = false;
    private int random; // speichert kurz zufälligen Wert aus dem Array

    public int random1; // speichert kurz zufälligen Wert

    private void Start()
    {
        random1 = Random.Range(0, 3); // Sucht zufälligen Wert aus
        Debug.Log(random1);

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

    public void PressurePlateCheck()
    {
        /*
        if(random1 == 0)
        {
          if (isPressurePlate1Pressd) // Richtige Reihnfolge wurde 1 platte richtig gedrückt )
          {
              pressurePlate1.SetActive(false);
              pressurePlate1Active.SetActive(true);
              isCorrectOrder = true;
              isSpawnComplete = false;
          }

          if (isPressurePlate1Pressd && isPressurePlate2Pressd && isCorrectOrder)
          {
              pressurePlate2.SetActive(false);
              pressurePlate2Active.SetActive(true);
              isCorrectOrder = true;
          }

          if (isPressurePlate1Pressd && isPressurePlate2Pressd && isPressurePlate3Pressd && isCorrectOrder)
          {
              pressurePlate3.SetActive(false);
              pressurePlate3Active.SetActive(true);
              isCorrectOrder = true;
          }

          if (isPressurePlate1Pressd && isPressurePlate2Pressd && isPressurePlate3Pressd && isPressurePlate4Pressd && isCorrectOrder)
          {
              pressurePlate4.SetActive(false);
              pressurePlate4Active.SetActive(true);
              isRiddleComplete = true;
          }

          // Reset
          if (isPressurePlate1Pressd && isPressurePlate3Pressd && !isPressurePlate2Pressd)
          {
              isCorrectOrder = false;
              isPressurePlate1Pressd = false;
              pressurePlate1.SetActive(true);
              pressurePlate1Active.SetActive(false);
              isPressurePlate3Pressd = false;
              pressurePlate3.SetActive(true);
              pressurePlate3Active.SetActive(false);
              // Spawn Enemys
              SpawnEnemys();
          }

          if (isPressurePlate1Pressd && isPressurePlate4Pressd && !isPressurePlate2Pressd)
          {
              isCorrectOrder = false;
              isPressurePlate1Pressd = false;
              pressurePlate1.SetActive(true);
              pressurePlate1Active.SetActive(false);
              isPressurePlate4Pressd = false;
              pressurePlate4.SetActive(true);
              pressurePlate4Active.SetActive(false);
              // Spawn Enemys
              SpawnEnemys();
          }

          if (!isPressurePlate1Pressd && isPressurePlate2Pressd)
          {
              isCorrectOrder = false;
              isPressurePlate2Pressd = false;
              pressurePlate2.SetActive(true);
              pressurePlate2Active.SetActive(false);
              // Spawn Enemys
              SpawnEnemys();
          }

          if (!isPressurePlate1Pressd && !isPressurePlate2Pressd && isPressurePlate3Pressd && !isPressurePlate4Pressd)
          {
              isCorrectOrder = false;
              isPressurePlate3Pressd = false;
              pressurePlate3.SetActive(true);
              pressurePlate3Active.SetActive(false);
              // Spawn Enemys
              SpawnEnemys();
          }

          if (!isPressurePlate1Pressd && !isPressurePlate2Pressd && !isPressurePlate3Pressd && isPressurePlate4Pressd)
          {
              isCorrectOrder = false;
              isPressurePlate4Pressd = false;
              pressurePlate4.SetActive(true);
              pressurePlate4Active.SetActive(false);
              // Spawn Enemys
              SpawnEnemys();
          }

          if (isPressurePlate1Pressd && isPressurePlate2Pressd && !isPressurePlate3Pressd && isPressurePlate4Pressd)
          {
              isCorrectOrder = false;
              isPressurePlate1Pressd = false;
              pressurePlate1.SetActive(true);
              pressurePlate1Active.SetActive(false);
              isPressurePlate2Pressd = false;
              pressurePlate2.SetActive(true);
              pressurePlate2Active.SetActive(false);
              isPressurePlate4Pressd = false;
              pressurePlate4.SetActive(true);
              pressurePlate4Active.SetActive(false);
              // Spawn Enemys
              SpawnEnemys();
          }
      }
          */
        if (random1 == 0)
        {
            if (isPressurePlate1Pressd) // Richtige Reihnfolge wurde 1 platte richtig gedrückt )
            {
                pressurePlate1.SetActive(false);
                pressurePlate1Active.SetActive(true);
                isCorrectOrder = true;
                isSpawnComplete = false;
            }

            if (isPressurePlate1Pressd && isPressurePlate4Pressd && isCorrectOrder)
            {
                pressurePlate4.SetActive(false);
                pressurePlate4Active.SetActive(true);
                isCorrectOrder = true;
            }

            if (isPressurePlate1Pressd && isPressurePlate4Pressd && isPressurePlate3Pressd && isCorrectOrder)
            {
                pressurePlate3.SetActive(false);
                pressurePlate3Active.SetActive(true);
                isCorrectOrder = true;
            }

            if (isPressurePlate1Pressd && isPressurePlate4Pressd && isPressurePlate3Pressd && isPressurePlate2Pressd && isCorrectOrder)
            {
                pressurePlate2.SetActive(false);
                pressurePlate2Active.SetActive(true);
                isRiddleComplete = true;
            }

            // Reset
            if (isPressurePlate1Pressd && isPressurePlate3Pressd && !isPressurePlate4Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate1Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                isPressurePlate3Pressd = false;
                pressurePlate3.SetActive(true);
                pressurePlate3Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (isPressurePlate1Pressd && isPressurePlate2Pressd && !isPressurePlate4Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate1Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                isPressurePlate2Pressd = false;
                pressurePlate2.SetActive(true);
                pressurePlate2Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate1Pressd && isPressurePlate4Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate1Pressd && !isPressurePlate4Pressd && isPressurePlate3Pressd && !isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate3Pressd = false;
                pressurePlate3.SetActive(true);
                pressurePlate3Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate1Pressd && !isPressurePlate4Pressd && !isPressurePlate3Pressd && isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate2Pressd = false;
                pressurePlate2.SetActive(true);
                pressurePlate2Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (isPressurePlate1Pressd && isPressurePlate4Pressd && !isPressurePlate3Pressd && isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate1Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                isPressurePlate2Pressd = false;
                pressurePlate2.SetActive(true);
                pressurePlate2Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }
        }
        if (random1 == 1)
        {
            if (isPressurePlate3Pressd) // Richtige Reihnfolge wurde 1 platte richtig gedrückt )
            {
                pressurePlate3.SetActive(false);
                pressurePlate3Active.SetActive(true);
                isCorrectOrder = true;
                isSpawnComplete = false;
            }

            if (isPressurePlate3Pressd && isPressurePlate2Pressd && isCorrectOrder)
            {
                pressurePlate2.SetActive(false);
                pressurePlate2Active.SetActive(true);
                isCorrectOrder = true;
            }

            if (isPressurePlate3Pressd && isPressurePlate2Pressd && isPressurePlate1Pressd && isCorrectOrder)
            {
                pressurePlate1.SetActive(false);
                pressurePlate1Active.SetActive(true);
                isCorrectOrder = true;
            }

            if (isPressurePlate3Pressd && isPressurePlate2Pressd && isPressurePlate1Pressd && isPressurePlate4Pressd && isCorrectOrder)
            {
                pressurePlate4.SetActive(false);
                pressurePlate4Active.SetActive(true);
                isRiddleComplete = true;
            }

            // Reset
            if (isPressurePlate1Pressd && isPressurePlate3Pressd && !isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate1Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                isPressurePlate3Pressd = false;
                pressurePlate3.SetActive(true);
                pressurePlate3Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (isPressurePlate3Pressd && isPressurePlate4Pressd && !isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate3Pressd = false;
                pressurePlate3.SetActive(true);
                pressurePlate3Active.SetActive(false);
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate3Pressd && isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate2Pressd = false;
                pressurePlate2.SetActive(true);
                pressurePlate2Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate3Pressd && !isPressurePlate2Pressd && isPressurePlate1Pressd && !isPressurePlate4Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate1Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate3Pressd && !isPressurePlate2Pressd && !isPressurePlate1Pressd && isPressurePlate4Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (isPressurePlate3Pressd && isPressurePlate2Pressd && !isPressurePlate1Pressd && isPressurePlate4Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate3Pressd = false;
                pressurePlate3.SetActive(true);
                pressurePlate3Active.SetActive(false);
                isPressurePlate2Pressd = false;
                pressurePlate2.SetActive(true);
                pressurePlate2Active.SetActive(false);
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }
        }
        if (random1 == 2)
        {
            if (isPressurePlate4Pressd) // Richtige Reihnfolge wurde 1 platte richtig gedrückt )
            {
                pressurePlate4.SetActive(false);
                pressurePlate4Active.SetActive(true);
                isCorrectOrder = true;
                isSpawnComplete = false;
            }

            if (isPressurePlate4Pressd && isPressurePlate2Pressd && isCorrectOrder)
            {
                pressurePlate2.SetActive(false);
                pressurePlate2Active.SetActive(true);
                isCorrectOrder = true;
            }

            if (isPressurePlate4Pressd && isPressurePlate2Pressd && isPressurePlate3Pressd && isCorrectOrder)
            {
                pressurePlate3.SetActive(false);
                pressurePlate3Active.SetActive(true);
                isCorrectOrder = true;
            }

            if (isPressurePlate4Pressd && isPressurePlate2Pressd && isPressurePlate3Pressd && isPressurePlate1Pressd && isCorrectOrder)
            {
                pressurePlate1.SetActive(false);
                pressurePlate1Active.SetActive(true);
                isRiddleComplete = true;
            }

            // Reset
            if (isPressurePlate4Pressd && isPressurePlate3Pressd && !isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                isPressurePlate3Pressd = false;
                pressurePlate3.SetActive(true);
                pressurePlate3Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (isPressurePlate4Pressd && isPressurePlate1Pressd && !isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                isPressurePlate1Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate4Pressd && isPressurePlate2Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate2Pressd = false;
                pressurePlate2.SetActive(true);
                pressurePlate2Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate4Pressd && !isPressurePlate2Pressd && isPressurePlate3Pressd && !isPressurePlate1Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate3Pressd = false;
                pressurePlate3.SetActive(true);
                pressurePlate3Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (!isPressurePlate4Pressd && !isPressurePlate2Pressd && !isPressurePlate3Pressd && isPressurePlate1Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate4Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }

            if (isPressurePlate4Pressd && isPressurePlate2Pressd && !isPressurePlate3Pressd && isPressurePlate1Pressd)
            {
                isCorrectOrder = false;
                isPressurePlate4Pressd = false;
                pressurePlate4.SetActive(true);
                pressurePlate4Active.SetActive(false);
                isPressurePlate2Pressd = false;
                pressurePlate2.SetActive(true);
                pressurePlate2Active.SetActive(false);
                isPressurePlate1Pressd = false;
                pressurePlate1.SetActive(true);
                pressurePlate1Active.SetActive(false);
                // Spawn Enemys
                SpawnEnemys();
            }
        }
    }

    public void SpawnEnemys()
    {
        if (!isSpawnComplete)
        {
            //Invoke("StartSpawn", 0.1f); //Wartet 1 Sekunde
            random = Random.Range(0, enemyList.Length); // Sucht zufälligen Längenwert dem Arrays aus
            Instantiate(enemyList[random], spawnPoint.position, Quaternion.identity);
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

