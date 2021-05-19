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
    private Hero HeroScript;
    public Image timeRewindImage;
    public int timeRewind = 0;
    public int timeRewindCooldown;

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
    public int healthRecover = 10;

    [Header("Player Health:")]
    public int hp;
    public int maxHp;
    private Text hpText;

    public void Start()
    {
        timeRewindImage.enabled = false;
    }

    public void Update()
    {
        hpText = GameObject.FindGameObjectWithTag("Hp Text").GetComponent<Text>();
        coinsText = GameObject.FindGameObjectWithTag("Coin Text").GetComponent<Text>();
        healthpotionsText = GameObject.FindGameObjectWithTag("Healthpotion Text").GetComponent<Text>();

        ActiveScene = SceneManager.GetActiveScene().name.ToString();

        // Relikte
        if (timeRewind == 0) // begrenzen der einsammelbaren Relikte
        {
            isRelictCollectable = true;
        }
        else if (timeRewind == 1)
        {
            isRelictCollectable = false;
            timeRewindImage.enabled = true;
        }

        if (Input.GetKeyDown(UseRelict) && timeRewind > 0 && relictCharge == 2)
        {
            GameObject character = GameObject.Find("Hero");
            if (character != null)
            {
                HeroScript = character.GetComponent<Hero>();
                HeroScript.nextRollTime = 0; // setze cooldown auf 0
                relictCharge = 0;
            }
            else
            {
                Debug.Log("Player wurde nicht gefunden!");
            }
        }


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
            healthpotions--;
            hp += healthRecover;

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






