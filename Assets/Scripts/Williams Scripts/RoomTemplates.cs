using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    // Erstellen von Arrays f�r die R�ume
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom; // gespeicherter Raum zum schlie�en von �ffnungen

    public List<GameObject> rooms; // Liste an R�umen

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;


    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
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
