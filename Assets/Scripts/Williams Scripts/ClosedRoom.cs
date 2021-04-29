using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClosedRoom : MonoBehaviour
{
    public Tilemap map;

    /*
    public GameObject DoorTop;
    public GameObject DoorBot;
    public GameObject DoorRight;
    public GameObject DoorLeft;
    */

    public bool StartRoom;
    public int KillsRequired;

    void Start()
    {
        //GetComponent<BoxCollider2D>().enabled = false; // schaltet den Box Collider aus
        /*
        DoorTop.SetActive(true);
        DoorBot.SetActive(true);
        DoorRight.SetActive(true);
        DoorLeft.SetActive(true);
        */
        //Tilemap tilemap = GetComponent<Tilemap>();
        //tilemap.SetTile(new Vector3Int(0, 0, 0), null); // Remove tile at 0,0,0
        //KillsRequired++; // test
    }

    private void Update()
    {
        if (KillsRequired == 0 && StartRoom == false) // Wenn benötigte Kills bei 0 liegen, öffne die Tür
        {
            DoorOpener();
          //KillsRequired = 0;
        }
        if (StartRoom == true)
        {
            DoorOpener();
        }
        else if (KillsRequired > 0 && StartRoom == false)
        {
            DoorLock();
        }
    }

    private void DoorOpener()
    {
        /*
        DoorTop.SetActive(false);
        DoorBot.SetActive(false); 
        DoorRight.SetActive(false); 
        DoorLeft.SetActive(false); 
        */
        //Tilemap tilemap = GetComponent<Tilemap>();
        // tilemap.SetTile(new Vector3Int(0, 0, 0), null); // Remove tile at 0,0,0
        GetComponent<TilemapRenderer>().enabled = false;
        GetComponent<TilemapCollider2D>().enabled = false;
    }

    private void DoorLock()
    {
        GetComponent<TilemapRenderer>().enabled = true;
        GetComponent<TilemapCollider2D>().enabled = true;
        /*
        DoorTop.SetActive(true);
        DoorBot.SetActive(true);
        DoorRight.SetActive(true);
        DoorLeft.SetActive(true);
        */
    }
    /* //////////////////////////////////////// Buggy
    public void OnCollisionStay2D(Collider2D other) // Wenn Collider von Anfang an auf gegner trifft, werden verschwindet das Object :(
    {
        if (other.CompareTag("Enemy"))
        {
            KillsRequired++;
        }
    }
    */
    
    public void OnTriggerEnter2D(Collider2D other) // Wenn Collider von Anfang an auf gegner trifft, werden verschwindet das Object :(
    {
        if (other.CompareTag("Enemy"))
        {
            KillsRequired++;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            KillsRequired--;
        }
    }
}
