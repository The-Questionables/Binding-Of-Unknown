using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode shoot = KeyCode.Space;
    public KeyCode turnleft = KeyCode.Q;
    public KeyCode turnright = KeyCode.E;

    void Update() 
    {

        bool left2 = Input.GetKey(left);

        if (left2 == true && transform.position.x >= -7.5f)
        {
            SendMessage("MoveLeft", SendMessageOptions.DontRequireReceiver);
        }

        bool right2 = Input.GetKey(right);

        if (right2 == true && transform.position.x <= 7.5f)
        {
            SendMessage("MoveRight", SendMessageOptions.DontRequireReceiver);
        }

        bool up2 = Input.GetKey(up);

        if (up2 == true && transform.position.y <= 8.75f)
        {
            SendMessage("MoveUp", SendMessageOptions.DontRequireReceiver);
        }

        bool down2 = Input.GetKey(down);

        if (down2 == true && transform.position.y >= 0f)
        {
            SendMessage("MoveDown", SendMessageOptions.DontRequireReceiver);
        }

        bool turnleft2 = Input.GetKey(turnleft);

        if (turnleft2 == true)
        {
            SendMessage("TurnLeft", SendMessageOptions.DontRequireReceiver);
        }

        bool turnright2 = Input.GetKey(turnright);

        if (turnright2 == true)
        {
            SendMessage("TurnRight", SendMessageOptions.DontRequireReceiver);
        }

        bool shoot2 = Input.GetKey(shoot);

        if (shoot2 == true)
        {
            SendMessage("Shoot", SendMessageOptions.DontRequireReceiver);
        }

       // if (Input.GetMouseButtonDown(1) && GlobalEvent.TriggerCurrentPowerUp != null)
       //     GlobalEvent.TriggerCurrentPowerUp();
    }
    

}
