using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Infos für LeverRoom-Script
    LeverRoom leverRoom;

    public bool isItpressurePlate1 = false;
    public bool isItpressurePlate2 = false;
    public bool isItpressurePlate3 = false;
    public bool isItpressurePlate4 = false;

    private void Update()
    {
        leverRoom = GameObject.FindGameObjectWithTag("LeverRoom").GetComponentInChildren<LeverRoom>(); // auf unterobject zugreifen
    }

    public void OnTriggerEnter2D(Collider2D other) // Wenn Collider von Anfang an auf gegner trifft, werden verschwindet das Object :(
    {
        if (isItpressurePlate1 == true && other.CompareTag("Player"))
        {
            // Farbe der Bodenplatte ändern wenn man richtig steht, ansonsten Gegner spawnen
            leverRoom.isPressurePlate1Pressd = true;
            // Randomizen der Zahl
            leverRoom.isCorrectPressurePlate3Pressd = true;
        }
        
        if (isItpressurePlate2 == true && other.CompareTag("Player"))
        {
            leverRoom.isPressurePlate2Pressd = true;
            leverRoom.isCorrectPressurePlate2Pressd = true;
        }
        if (isItpressurePlate3 == true && other.CompareTag("Player"))
        {
            leverRoom.isPressurePlate3Pressd = true;
            leverRoom.isCorrectPressurePlate4Pressd = true;
        }
        if (isItpressurePlate4 == true && other.CompareTag("Player"))
        {
            leverRoom.isPressurePlate4Pressd = true;
            leverRoom.isCorrectPressurePlate1Pressd = true;
        }
    }
}
