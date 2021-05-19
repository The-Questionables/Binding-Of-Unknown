using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelictSpawner : MonoBehaviour
{
    public GameObject[] RelictList; // Array an Items
    private int random; // speichert kurz zufälligen Wert aus dem Array
    private bool lootSpawned = false; // sorgt dafür das Räume nicht gleichzeitig spawnen

    void Start()
    {
        Invoke("RelictSpawn", 0.2f); // aktiviert Methode mit einen Time delay
    }

    public void RelictSpawn()
    {
        if (lootSpawned == false) 
        {
            random = Random.Range(0, RelictList.Length); // Sucht zufälligen Längenwert des Arrays aus

            if (RelictList[random] == null)
            {
               random = Random.Range(0, RelictList.Length); // Sucht einen neuen zufälligen Längenwert des Arrays aus
            }
            Instantiate(RelictList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            (RelictList[random]) = null; // löscht das Gameobject aus dem Array
        }
        lootSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }
}
