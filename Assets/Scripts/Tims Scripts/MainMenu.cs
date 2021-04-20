using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level 1 Williams Scene");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitButton() 
    {
        Application.Quit();
        Debug.Break();
    }

   
}
