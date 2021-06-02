using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header("Relicts:")]
    public bool isRelictCollectable;
    public KeyCode UseRelict = KeyCode.E;

    // Fähigkeit Time Rewind
    public int timeRewind = 0;
    public int timeRewindCooldown;

    // Fähikeit Totem
    public int totem = 0;
    public int totemboost = 2;

    [Header("RelictBar:")]
    public int relictCharge;
    public int maxRelictCharge;

    [Header("Coins:")]
    public int coins;
    private Text coinsText;

    [HideInInspector] public string ActiveScene;
    [Header("Healthpotions:")]
    public bool isHealpotionCollectable;
    private Text healthpotionsText;
    public KeyCode UseHealthpotion = KeyCode.Q;
    public int healthpotions;
    public int maxHealthpotions;
    public int healthRecover = 15;

    [Header("Player Health:")]
    public int hp;
    public int maxHp;
    private Text hpText;

    public void Update()
    {
        hpText = GameObject.FindGameObjectWithTag("Hp Text").GetComponent<Text>();
        coinsText = GameObject.FindGameObjectWithTag("Coin Text").GetComponent<Text>();
        healthpotionsText = GameObject.FindGameObjectWithTag("Healthpotion Text").GetComponent<Text>();

        ActiveScene = SceneManager.GetActiveScene().name.ToString();

        coinsText.text = "x" + coins.ToString();
        healthpotionsText.text = healthpotions.ToString() + "/" + maxHealthpotions.ToString();
        hpText.text = hp.ToString() + "/" + maxHp.ToString();

        if (healthpotions < maxHealthpotions) // begrenzen der einsammelbaren Heiltränke
        {
            isHealpotionCollectable = true;
        }
        else if (healthpotions >= maxHealthpotions)
        {
            isHealpotionCollectable = false;
        }

        if (Input.GetKeyDown(UseHealthpotion) && healthpotions > 0 && hp < maxHp)
        {
            if (totem >= 1)
            {
                healthpotions--;
                hp += healthRecover * totemboost;
            }
            else
            {
                healthpotions--;
                hp += healthRecover;
            }
            if ((hp + healthpotions) > maxHp)
            {
                hp = maxHp;
            }
        }   
    }

    void OnLevelWasLoaded()
    {
        if (ActiveScene == "Upper World")
        {
            hp = maxHp;
            SaveGame();
        }
        else if (ActiveScene == "Main Menu")
        {
            Destroy(this);
        }
    }

    public void SaveGame()
    {
        SaveGameSystem.SaveGame(this);
    }
    /*
    public void LoadGame()
    {
        SaveGameData data = SaveGameSystem.LoadData();

        coins = data.coins;
        hp = data.health;
        healthpotions = data.healthpotions;
        maxHealthpotions = data.maxHealthpotions;
        ActiveScene = data.level;
    }
    */
}






