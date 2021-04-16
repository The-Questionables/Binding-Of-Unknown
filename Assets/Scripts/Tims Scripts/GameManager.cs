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
    public int PlayerHitpoints = 10;
    public int PlayerMana = 10;
    public bool IsUsingOldSystem = true;

    void Update()
    {
        if (Live)
            Live.value = PlayerHitpoints;
        if (Score)
            Score.text = "Score: " + score;   
    }
}
