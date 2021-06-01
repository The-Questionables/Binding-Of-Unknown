using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{   
    [Tooltip("insert the name of the scene that you want the portal to lead to here")]
    public string Scene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            SceneManager.LoadScene(Scene); 
        }
    }

}
