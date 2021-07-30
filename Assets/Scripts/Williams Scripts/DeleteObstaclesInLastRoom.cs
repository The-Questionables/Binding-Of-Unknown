using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObstaclesInLastRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacles"))
        {
            Debug.Log("Obstacles destroyt!");
            Destroy(other.gameObject);
        }
    }
}


