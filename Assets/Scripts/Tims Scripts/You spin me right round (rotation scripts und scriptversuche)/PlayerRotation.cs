using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    void Update()
    {
    Vector3 position = Camera.current.WorldToScreenPoint(transform.position);
    Vector3 direction = Input.mousePosition - position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
}
