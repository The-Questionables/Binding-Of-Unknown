using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private Scene scene;
    public bool isPlayerInRoom = false;
    public bool isSpawnComplete = false;

    private float randomXposition;
    private float randomYposition;
    private Vector3 randomSpawnPosition;
    private int random; // speichert zufälligen Wert aus dem Array
    public BoxCollider2D spawnArea;

    [Header("Intervals")] //Fügt Überschrift ein
    private float enemySpawnInterval; //Zeitraum zwischen den spawn der Gegner
    private float waveSpawnInterval; // Zeitraum zwischen den Wellen

    [Header("Enemys")] 
    public GameObject[] enemyList; // Array an Gegnern
    private int enemyAmountForThisRoom;
    bool spawnComplete;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level 1")
        {
            enemyAmountForThisRoom = 1;

            // Remove Element 4,5,6
            Destroy(enemyList[4]);
            Destroy(enemyList[5]);
            Destroy(enemyList[6]);
        }
        if (scene.name == "Level 2")
        {
            enemyAmountForThisRoom = 2;
            // Remove Element 5,6
            Destroy(enemyList[5]);
            Destroy(enemyList[6]);
        }
        if (scene.name == "Level 3")
        {
            enemyAmountForThisRoom = 3;
        }
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
            // Spawn der Gegner
            for (int i = 0; i < enemyAmountForThisRoom; i++)
            {
                // Wählt Zufälliger Ort in einen Raum
                randomXposition = Random.Range(-6f, 6f);
                randomYposition = Random.Range(-3f, 2f);
                randomSpawnPosition = new Vector3(randomXposition, randomYposition, 0f);

                // Spawnt gegner
                random = Random.Range(0, enemyList.Length); // Sucht zufälligen Längenwert dem Arrays aus
                Instantiate(enemyList[random], randomSpawnPosition + spawnArea.transform.position, Quaternion.identity);

               //Warten auf nächstes Spawn (interval)
                yield return new WaitForSeconds(enemySpawnInterval);
            }
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnWaves());
        CancelInvoke("StartSpawn"); //fürs debuggen
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRoom = true;
        }
    }
}