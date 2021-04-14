using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    // wird gebraucht f�r die Kameraverfolgung
    public int X;
    public int Y;

    // F�ge die R�ume in die Liste vom RoomTemplates hinzu
    private RoomTemplates templates;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

    public Vector3 GetRoomCentre()
    {
        return new Vector3(X, Y); //(X * Width, Y * Height);
    }
}
