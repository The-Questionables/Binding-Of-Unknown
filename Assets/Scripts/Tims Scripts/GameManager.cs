using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private bool autosave = false;

    // Infos für Quests
    QuestMenuOpener questMenuOpener;
    private Scene scene;

    // Quest verweise
    public Quest1 quest1; 
    public Quest2 quest2;
    public Quest3 quest3;

    [Header("Relicts:")]
    public bool isRelictCollectable;
    public KeyCode UseRelict = KeyCode.E;

    // Fähigkeit Time Rewind
    public int timeRewind = 0;
    public int timeRewindCooldown;

    // Fähikeit Totem
    public int totem = 0;
    public int totemboost = 2;

    // Fähigkeit Heavy Armor
    public int heavyArmor = 0;
    public float heavyArmorDamageReduction = 50;

    [Header("RelictBar:")]
    public int relictCharge;
    public int maxRelictCharge;

    [Header("Coins:")]
    public int coins;
    private Text coinsText;

    [HideInInspector] public string ActiveScene;
    [Header("Healthpotions:")]
    public KeyCode UseHealthpotion = KeyCode.Q;
    public bool isHealpotionCollectable;
    public int healthpotions;
    public int maxHealthpotions;
    public int healthRecover = 15;
    private Text healthpotionsText;

    [Header("Player Health:")]
    public int hp;
    public int maxHp;
    private Text hpText;

    [Header("Attack Damage:")]
    public int swordDamage = 10;
    public int bowDamage = 20;

    [HideInInspector] public bool bow_bought;

    public void Update()
    {
        if (ActiveScene == Slime_Const.Overworld_Name && autosave == true)
        {
            hp = maxHp;
            SaveGame();
            autosave = false;
        }

        // Quests
        scene = SceneManager.GetActiveScene();
        if (scene.name == Slime_Const.Overworld_Name)
        {            
            questMenuOpener = GameObject.FindGameObjectWithTag("QuestSystem").GetComponent<QuestMenuOpener>();
        }

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
            Healcounter(); // Healing Quest ////////////////////////////////////////////////////
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
        autosave = true;
        if (ActiveScene == Slime_Const.Overworld_Name)
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

    public void Healcounter()
    {
        if(quest3.isActive)
        {
            quest3.goal.HeroHeal();

            if (quest3.goal.IsReached())
            {
                coins += quest3.goldReward;
                quest3.CompleteQuest3();

                questMenuOpener.ResetQuests();
                Debug.Log("Quests Resetet");
            }
        }
    }
    public void Killcounter()
    {
        if (quest1.isActive) 
        {
            quest1.goal.EnemyKilled();
            
            if (quest1.goal.IsReached())
            {
                coins += quest1.goldReward;
                quest1.CompleteQuest1();

                questMenuOpener.ResetQuests();
                Debug.Log("Quests Resetet");
            }
        }

        if (quest2.isActive)
        {
            quest2.goal.EnemyKilled();

            if (quest2.goal.IsReached())
            {
                coins += quest2.goldReward;
                quest2.CompleteQuest2();

                questMenuOpener.ResetQuests();
                Debug.Log("Quests Resetet");
            }
        }
    }
}






