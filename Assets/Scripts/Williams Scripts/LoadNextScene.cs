using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // AudioSource.PlayClipAtPoint(NextLevelSound, Camera.main.transform.position, heartSoundVolume);
            // SceneManager.LoadScene("Upper World");
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            return;
        }
    }
}
