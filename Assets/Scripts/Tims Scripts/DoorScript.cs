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
        if (StartRoom == true)
        { 
            DoorOpener();
        }
        else if (StartRoom == false)
        {
            DoorLock();
        }
        else if (KillsRequired <= 0) 
        { 
            KillsRequired = 0;
            DoorOpener();
        }
    }

    // Update is called once per frame
    void OnTriggerExit2D()
    {
        DoorLock();
    }


    private void DoorOpener()
    {
        Door[1].SetActive(false);
        Door[2].SetActive(false);
        Door[3].SetActive(false);
        Door[4].SetActive(false);
    }
    private void DoorLock()
    {
        Door[1].SetActive(true);
        Door[2].SetActive(true);
        Door[3].SetActive(true);
        Door[4].SetActive(true);
    }
}