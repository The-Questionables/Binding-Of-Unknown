using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(NextLevelSound, Camera.main.transform.position, heartSoundVolume);
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            return;
        }
    }
}
