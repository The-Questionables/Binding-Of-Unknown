using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //public int required_kills = 100;
    //public float reqired_time = 120;
    //public int coins;
    public Text coinsText;

    public Slider Live;
    public Text HealthText;

    public int score = 0;
    public string Next_Stage = "";
    public int PlayerHitpoints = 10;
    public int PlayerMana = 10;

    void Update()
    {
        /*
        if (Live)
            Live.value = PlayerHitpoints;
        if (coins)
            coins.text = "Score: " + score;   
        */
    }

    public void AddCoin(int getCoins)
    {
        //coins += getCoins;
        UpdateCoinsText(getCoins);
    }
    public void UpdateCoinsText(int getCoins)
    {
        coinsText.text = "x" + getCoins.ToString();
        Debug.Log("UpdateCoinsText wurde ausgeführt");
    }
}

/*
public class UiScript : MonoBehaviour
{

    public static UiScript instance; // wird gebraucht zum kommunizierung der daten von den anderen Scripts

    public Text coinText;
    public Text lifeText;
    public Text stageText;
    public Text RocketText;
    public Text Healthtext;

    void Awake()
    {
        instance = this;
    }

    public void UpdateHealthText(int amount)
    {

        Healthtext.text = "x" + amount.ToString("D1");
    }

    public void UpdateRocketText(int amount)
    {

        RocketText.text = "x" + amount.ToString("D2");
    }

    // Text verändert sich je nach dem was passiert

    public void UpdateScoreText(int amount)
    {

        scoreText.text = amount.ToString("D8"); //steht für 9 Dezimalstellen
    }

    public void UpdateLifeText(int amount)
    {
        lifeText.text = "x" + amount.ToString("D1"); //steht für 2 Dezimalstellen
    }

    public void ShowStageText(int amount)
    {
        // stageText.gameObject.SetActive(true);
        stageText.text = "Stage " + amount;

        // Invoke("DeactivateStagetext", 3f);
    }

    //  void DeactivateStagetext()
    // {
    //     stageText.gameObject.SetActive(false);
    //      CancelInvoke("DeactivateStagetext");
    //  }

}
*/