using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //lege dieses Script in das entsprechende Canvas wo auch das Menü sich befindet, 
    //ziehe bei PauseMenuUI das Menü/Panel hinein

    public static bool GameIsPaused = false;    //setze den Wert ob das Spiel pausiert auf falsch

    public GameObject PauseMenuUI;
    //erstelle ein öffentliches Game-Object mit dem Namen Pause

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Credits")) { SceneManager.LoadScene("Main Menu"); }
            else
            {

                if (GameIsPaused)
                {
                    Resume();                   //rufe die Funktion Resume auf
                }

                else
                {
                    Pause();                    //rufe die Funktion Pause auf
                }
            }
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;                //setze die weiterlaufende Zeit auf 0
        GameIsPaused = true;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
    }
    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Break();
    }
}
