using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject DoorAnchor;
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
        DoorAnchor.SetActive(false);
    }
    private void DoorLock()
    {
        DoorAnchor.SetActive(true);
    }
}