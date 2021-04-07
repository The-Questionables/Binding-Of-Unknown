using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMenuOpener : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject CharMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("i"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Resume()
    {
        CharMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        CharMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
