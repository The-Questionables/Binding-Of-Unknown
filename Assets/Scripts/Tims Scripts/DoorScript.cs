using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject DoorAnchor;
    public bool StartRoom;

    void Start()
    {

    }

    private void Update()
    {
        if (StartRoom==true)
            DoorAnchor.SetActive(false);
        else if (StartRoom==false) {
            DoorAnchor.SetActive(true);
        }
    }

    // Update is called once per frame
    void OnTriggerExit()
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