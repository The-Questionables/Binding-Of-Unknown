using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //public int required_kills = 100;
    //public float reqired_time = 120;
    public int coins;
    public Text coinsText;

    public int healpotions;
    public Text healpotionsText;

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
    //*********************************** Coins
    public void AddCoin(int getCoins)
    {
        coins += getCoins;
        UpdateCoinsText(coins);
    }
    public void UpdateCoinsText(int coins)
    {
        coinsText.text = "x" + coins.ToString();
        Debug.Log("UpdateCoinsText wurde ausgeführt");
    }

    //********************************** Healpotions
    public void AddHealpotions(int getHealpotions)
    {
        healpotions += getHealpotions;
        UpdateHealpotionsText(healpotions);
    }
    public void UpdateHealpotionsText(int healpotions)
    {
        healpotionsText.text = "x" + healpotions.ToString();
        Debug.Log("UpdateCoinsText wurde ausgeführt");
    }
    public void UseHealpotions(int useHealpotions)
    {
        healpotions += useHealpotions; // benutzt - Wert um Healpotion zu nutzen
        UpdateHealpotionsText(healpotions);
    }
}


/*
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
*/