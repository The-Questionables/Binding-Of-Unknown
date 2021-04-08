using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //public int required_kills = 100;
    //public float reqired_time = 120;
    public Text Score;
    public Slider Live;
    public int score = 0;
    public string Next_Stage = "";
    public int PlayerHitpoints = 3;
    public bool IsUsingOldSystem = true;

    void Update()
    {
        /* if (PlayerHitpoints<=0)
         {
             SceneManager.LoadScene("Main Menu");
         }*/
        //if (reqired_time >= 0)
        //{ reqired_time -= Time.deltaTime; }
        if (Live)
            Live.value = PlayerHitpoints;
        if (Score)
            Score.text = "Score: " + score;
        /*
        if (IsUsingOldSystem == true)
        {
            if (required_kills <= 0 && reqired_time <= 0)
            {
                SceneManager.LoadScene(Next_Stage);
            }
        }
        */
    }
}
