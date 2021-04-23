using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject[] Door;
    public bool StartRoom;
    public int KillsRequired;

    void Start()
    {

    }

    private void Update()
    {
        if (KillsRequired <= 0 && StartRoom == false) 
        { 
            DoorOpener();
            KillsRequired = 0;
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

    // Update is called once per frame
    void OnTriggerExit2D()
    {
        DoorLock();
    }


    private void DoorOpener()
    {
        int x = 0;
        while (x < Door.Length)
        {
            Door[x].SetActive(false);
            x++;
        }
    }
    private void DoorLock()
    {
        int x = 0;
        while (x < Door.Length)
        {
            Door[x].SetActive(true);
            x++;
        }
    }
}