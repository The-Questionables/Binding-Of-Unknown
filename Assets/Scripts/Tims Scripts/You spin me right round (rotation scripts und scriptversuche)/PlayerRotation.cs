using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SendMessage("TurnLeft", SendMessageOptions.DontRequireReceiver);
        }
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            SendMessage("TurnRight", SendMessageOptions.DontRequireReceiver);
        }
    }
}
