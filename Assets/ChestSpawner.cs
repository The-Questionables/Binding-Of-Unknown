using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public bool startRoom;
    public bool endRoom;
    public int enemyCounter;

    public GameObject[] chestList; // Array an verschiedenen Kisten
    private int random; // speichert kurz zufälligen Wert aus dem Array
    private bool chestSpawned; // sorgt dafür das Kisten nicht gleichzeitig spawnen
    private float timer;
    public float spawntime = 3;

    private void Update()
    {
        if (timer >= spawntime) 
        { 
        if (enemyCounter == 0 && startRoom == false)
        {
            SpawnChest();
        }
            if (startRoom == true)
            {
                SpawnChest();
            }
            else if (enemyCounter > 0 && startRoom == false)
            {
                DeleteChest();
            }
        }
        else 
        {
            timer += Time.deltaTime;
        }
    }

    public void DeleteChest()
    {
        // Löschen der ausversehen gespawnten Kiste
        //Destroy(chest, 2.0f);
        // Hier auf Instantiaties Gameobject zugreifen und zerstören
    }

    public void SpawnChest()
    {
        if (chestSpawned == false)
        { 
            random = Random.Range(0, chestList.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
            GameObject chest = Instantiate(chestList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
        }
            chestSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCounter++;
            Debug.Log("Enemy detacted");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCounter--;
        }
    }
}