using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomingPig : MonoBehaviour
{
    public float speed = 2.0f;
    public float minDistance = 3.0f;
    public float maxDistance = 10.0f;
    public float speed_after_chase = 4.0f;
    float old;
    public Movement mov;
    Transform playerTransform;
    Vector3 direction;
    
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Slime_Const.Tag_Player).transform;
        old = mov.Speed ;
    }

    void Update()
    {
        direction = playerTransform.position - transform.position;
        float distance = direction.magnitude;
        if (distance >= minDistance && distance <= maxDistance)
        {
            direction /= distance;
            transform.position += direction * Time.deltaTime * speed;
            mov.Speed = 0;
        }
        else {  
            mov.Speed = old;
           
            }
    }
}
