using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private bool autosave = false;

    // Infos für Quests
    QuestMenuOpener questMenuOpener;
    QuestGoal questGoal;

    private Scene scene;

    // Quest verweise
    public Quest1 quest1; 
    public Quest2 quest2;
    public Quest3 quest3;
    public bool isQuestComlete;
    public float enemyCounter;
    public float healCounter;

    // UI Relikte
    public Text questInfoText;
    public GameObject questInfoImage;
    public Image background;
    public GameObject questUI;

    [Header("Relicts:")]
    public bool isRelictCollectable;
    //public KeyCode UseRelict = KeyCode.E;

    // UI Relikte
    public bool isTimeRewindActive;
    public bool isTotemActive;
    public bool isArmorActive;

    // Fähigkeit Time Rewind
    public int timeRewind = 0;
    public int timeRewindCooldown;

    // Fähikeit Totem
    public int totem = 0;
    public int totemboost = 2;

    // Fähigkeit Heavy Armor
    public int heavyArmor = 0;
    public float heavyArmorDamageReduction = 50;

    //[Header("RelictBar:")]
    //public int relictCharge;
    //public int maxRelictCharge;

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
    [HideInInspector] public bool isHealportUp;
    [HideInInspector] public bool chest_of_everlasting_wealth = false;
    [HideInInspector] public bool Screenshake;

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

        
        if (scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3" || scene.name == Slime_Const.Overworld_Name)
        {
                questInfoText = GameObject.FindGameObjectWithTag("QuestInfoText").GetComponent<Text>();
                questInfoImage = GameObject.FindGameObjectWithTag("questInfoImage");

               if (questInfoImage != null)
               {
                   background = questInfoImage.GetComponent<Image>();
               }

            questUI = GameObject.FindGameObjectWithTag("questInfoImage");

            if (quest1.isActive)
            {
                background.enabled = true;
                //ShowQuestText("Kill 30 Monsters " + "0/30");
                ShowQuestText("Kill 30 Monsters " + enemyCounter + "/ 30");
                isQuestComlete = true;
            }
            if (quest2.isActive)
            {
                background.enabled = true;
                ShowQuestText("Kill 15 Monsters " + enemyCounter + "/ 15");
                isQuestComlete = true;
                Debug.Log("Quest2 wurde angenommen");
            }
            if (quest3.isActive)
            {
                background.enabled = true;
                ShowQuestText("Use 3 Heal Potions " + healCounter + "/3");
                isQuestComlete = true;
            }
            else if (isQuestComlete == false)
            {
                 //Hintergrund austellen, Text nicht anzeigen, Problem = wird jede Sekunde ausgeführt
                 background.enabled = false;
                 questInfoText.text = "";
                 //isQuestTaken = false;
            }  
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
            healCounter++;
            ShowQuestText("Use 3 Healpotions " + healCounter + "/ 3");

            if (quest3.goal.IsReached())
            {
                DeactivateQuestText(); // Show Quest Complete
                // if(scene.name == Slime_Const.Overworld_Name) //if (questMenuOpener.isPlayerInRange == true)
               // {
                    // Quest Abgeben um Belohnung abzuholen einbauen
                    coins += quest3.goldReward;
                    quest3.CompleteQuest3();

                    questMenuOpener.ResetQuests();
                    healCounter = 0;
                    Debug.Log("Quests Resetet");
                //}
            }
        }
    }
    public void Killcounter()
    {
        if (quest1.isActive) 
        {
            quest1.goal.EnemyKilled();
            enemyCounter++;
            ShowQuestText("Kill 30 Monsters " + enemyCounter + "/ 30");

            if (quest1.goal.IsReached())
            {
                DeactivateQuestText();


                coins += quest1.goldReward;
                quest1.CompleteQuest1();

                questMenuOpener.ResetQuests();
                enemyCounter = 0;
                Debug.Log("Quests Resetet");
            }
        }

        if (quest2.isActive)
        {
            quest2.goal.EnemyKilled();
            enemyCounter++;
            ShowQuestText("Kill 30 Monsters " + enemyCounter + "/ 30");

            if (quest2.goal.IsReached())
            {
                DeactivateQuestText();


                coins += quest2.goldReward;
                quest2.CompleteQuest2();

                questMenuOpener.ResetQuests();
                enemyCounter = 0;
                Debug.Log("Quests Resetet");
            }
        }
    }
    void ShowQuestText(string text)
    {
        background.enabled = true; // Schaltet Background ein
        questInfoText.text = "" + text;
        //Invoke("DeactivateStagetext", 6f);
    }

    void DeactivateQuestText()
    {
        questInfoText.text = "Quest Complete";

        //CancelInvoke("DeactivateStagetext");
    }
}






