using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInput : MonoBehaviour
{


    void Update() 
    {
            SendMessage("MoveBullet", SendMessageOptions.DontRequireReceiver);
    }


}
