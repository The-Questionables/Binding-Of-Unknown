using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection; // Setzt wert je nachdem welche Tür benötigt wird
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates; // ermöglicht zugriff zu allen Arrays die Räume enthalten 
    private int random; // speichert zufälligen Wert aus dem Array
    private bool spawned = false; // sorgt dafür das Räume nicht gleichzeitig spawnen
    private float waitTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime); // Zerstört Spawner nach einer bestimmten Zeit
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f); // aktiviert Methode mit einen Time delay
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            // Need to spawn a room with a bottom door
            {
                random = Random.Range(0, templates.bottomRooms.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
                Instantiate(templates.bottomRooms[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
               // Instantiate(templates.bottomRooms[random], transform.position, templates.bottomRooms[random].transform.rotation);
            }
            else if (openingDirection == 2)
            // Need to spawn a room with a top door
            {
                random = Random.Range(0, templates.topRooms.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
                Instantiate(templates.topRooms[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            }
            else if (openingDirection == 3)
            // Need to spawn a room with a left door
            {
                random = Random.Range(0, templates.leftRooms.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
                Instantiate(templates.leftRooms[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            }
            else if (openingDirection == 4)
            // Need to spawn a room with a right door
            {
                random = Random.Range(0, templates.rightRooms.Length); // Sucht zufälligen Längenwert des BottomRoom Arrays aus
                Instantiate(templates.rightRooms[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            }
            spawned = true; // setzt bool auf true damit keine weiteren Räume mehr spawnen
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // wird aktiviert wenn der collider mit was zusammenstößt
    {
        if(other.CompareTag("SpawnPoint")) // wenn der Spawn point mit was zusammenstößt und bereits ein Raum gespawnt ist
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                // spawn walls blocking off any openings!
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject); // zerstöre den Spawner damit nichts mehr nachspawnt
            }
            spawned = true; // verhindert weiteres nachspawnen
        }
    }
}
