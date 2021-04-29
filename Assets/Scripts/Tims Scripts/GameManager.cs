using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header("Coins:")]
    public int coins;
    public Text coinsText;

    [Header("Healthpotions:")]
    public int healpotions;
    public int maxHealthpotionsSlots;
    public Text healpotionsText;
    public Text MaxHealthpotionsSlotsText;
    public bool isHealpotionCollectable;


    [Header("Player Health:")]
    public int currentHealth;
    public int maxHealth;
    public Text currentHealthText;
    public Text maxHealthText;

    // Cached References
    Hero hero;

    [Header("Tim´s Stuff:")]
    public Slider Live;
    public int score = 0;
    public string Next_Stage = "";
    public int PlayerHitpoints = 10;
    public int PlayerMana = 10;
    //public int required_kills = 100;
    //public float reqired_time = 120;

    public void Start()
    {
        hero = FindObjectOfType<Hero>();      
    }

    public void Update() 
    {
        if (healpotions < maxHealthpotionsSlots) // begrenzen der einsammelbaren Heiltränke
        { 
           isHealpotionCollectable = true;
        }
        else if (healpotions == maxHealthpotionsSlots) 
        {
            isHealpotionCollectable = false;
        }
    }

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
        healpotions -= useHealpotions; // benutzt - Wert um Healpotion zu nutzen
        UpdateHealpotionsText(healpotions);
    }

    //********************************** ShowMaxHealpotionsText
    public void GetMaxHealthpotionSlotsText(int getMaxHealpotions) // noch einbauen
    {
        maxHealthpotionsSlots += getMaxHealpotions;
        UpdateMaxHealthText(maxHealthpotionsSlots);
    }
    public void UpdateMaxHealpotionsSlots(int maxHealthpotions) // noch einbauen
    {
        MaxHealthpotionsSlotsText.text = "/" + maxHealthpotions.ToString();
        Debug.Log("UpdateMaxHealthText wurde ausgeführt");
    }

    //********************************** ShowCurrentHealthText
    public void GetCurrentHealthText(int getCurrentHealth) // noch einbauen
    {
        currentHealth += getCurrentHealth;
        UpdateCurrentHealthText(currentHealth);
    }
    public void UpdateCurrentHealthText(int currentHealth)
    {
        currentHealthText.text = currentHealth.ToString();
        Debug.Log("UpdateCurrentHealthText wurde ausgeführt");
    }
    public void DecreaseCurrentHealthText(int getDamage) // noch einbauen
    {
        currentHealth -= getDamage; // benutzt - Wert um Healpotion zu nutzen
        UpdateHealpotionsText(currentHealth);
    }

    //********************************** ShowMaxHealthText
    public void GetMaxHealthText(int getMaxHealth) // noch einbauen
    {
        maxHealth += getMaxHealth;
        UpdateMaxHealthText(maxHealth);
    }
    public void UpdateMaxHealthText(int maxHealth) // noch einbauen
    {
        maxHealthText.text = "/" + maxHealth.ToString();
        Debug.Log("UpdateMaxHealthText wurde ausgeführt");
    }
    /*
    public void DecreaseMaxHealthText(int getMaxHealth)
    {
        maxHealth -= getMaxHealth; // benutzt - Wert um Healpotion zu nutzen
        UpdateMaxHealthText(getMaxHealth);
    }
    */
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