using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnRoomTrigger : MonoBehaviour
{
    // Raum der Spawnt auf der Map
    //public GameObject[] Room;
    //public GameObject canvas;
    public GameObject room;
    // Spawnpoint
    public Transform SpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Icon"))
        {
            // Spawnt am Richtigen Ort aber Unsichbar
            //Instantiate(Room[0], SpawnPoint.position, Quaternion.identity); // Problem, spawnt nicht richtig
            //Instantiate(room, SpawnPoint.position, Quaternion.identity);
            //GameObject newRoom = Instantiate(room, SpawnPoint.position, Quaternion.identity) as GameObject;
            //newRoom.transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform, false);

            // Spawnt am falschen Ort
            //var createImage = Instantiate(room) as GameObject;
            //createImage.transform.SetParent(canvas.transform, false);

           // transform.position = SpawnPoint.position;

            Debug.Log("Raum wurde erstellt");
        }
        else
        {
            Debug.Log("Raum wurde nicht erstellt");
            return;
        }
    }
}
