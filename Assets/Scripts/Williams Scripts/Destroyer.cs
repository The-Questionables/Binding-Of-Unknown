using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}

/*
        if (other.gameObject.tag == "Player")
        {

        }
        else if (other.gameObject.tag == "Rooms")
        {

        }
        else if (other.gameObject.tag == "Enemy")
        {

        }
        else
        {
            Destroy(other.gameObject);
        }
*/