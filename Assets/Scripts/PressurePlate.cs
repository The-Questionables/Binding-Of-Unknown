using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Infos für LeverRoom-Script
    LeverRoom leverRoom;
    public GameObject riddleRoom;

    public bool isItpressurePlate1 = false;
    public bool isItpressurePlate2 = false;
    public bool isItpressurePlate3 = false;
    public bool isItpressurePlate4 = false;

    private void Update()
    {
        //leverRoom = GameObject.FindGameObjectWithTag("LeverRoom").GetComponentInChildren<LeverRoom>(); // auf unterobject zugreifen, // Problem wenn es 2 Räume in der Scene gibt
        leverRoom = riddleRoom.GetComponent<LeverRoom>();
    }

    public void OnTriggerEnter2D(Collider2D other) // Wenn Collider von Anfang an auf gegner trifft, werden verschwindet das Object :(
    {
        // Farbe der Bodenplatte ändern wenn man richtig steht, ansonsten Gegner spawnen

        if (isItpressurePlate1 == true && other.CompareTag("Player"))
        {          
            leverRoom.isPressurePlate1Pressd = true;         
        }
        
        if (isItpressurePlate2 == true && other.CompareTag("Player"))
        {
            leverRoom.isPressurePlate2Pressd = true;
        }
        if (isItpressurePlate3 == true && other.CompareTag("Player"))
        {
            leverRoom.isPressurePlate3Pressd = true;
        }
        if (isItpressurePlate4 == true && other.CompareTag("Player"))
        {
            leverRoom.isPressurePlate4Pressd = true;
        }       
    }
}
