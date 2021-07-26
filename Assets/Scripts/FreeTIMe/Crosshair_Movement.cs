using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair_Movement : MonoBehaviour
{
    public bool sword;
    public KeyCode SwordKey;
    void Update()
    {
        if (Input.GetKeyDown(SwordKey))
        {
            if (sword == false)
                sword = true;
            else if (sword == true)
            {
                sword = false;
            }
        }
        if (sword == false)
        {
            Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
       else
        {
            Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

