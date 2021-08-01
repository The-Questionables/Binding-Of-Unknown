using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    private GameObject[] LoadObjs;
    public GameManager gm;
    public bool searchforgamemaster=false;

    private void Awake()
    {
        if (LoadObjs != null && LoadObjs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Update()
    {
        if (searchforgamemaster==true)
        {
            gm = FindObjectOfType<GameManager>();
            LoadOnEventOfYourChoice();
        }
    }

    public void LoadOnEventOfYourChoice()
    {
        SaveGameData data = SaveGameSystem.LoadData();

        if (gm == null)
        {
            SceneManager.LoadScene(data.level);
            searchforgamemaster = true;
        }
        else
        {
            //
            gm.quest1 = data.quest1;
            gm.quest2 = data.quest2;
            gm.quest3 = data.quest3;
            //
            gm.healCounter = data.healCounter;
            gm.enemyCounter = data.enemyCounter;
            //
            gm.Screenshake = data.screen_shake_active;
            gm.coins = data.coins;
            gm.bow_bought = data.bow;
            gm.hp = data.health;
            gm.maxHp = data.maxHealth;
            gm.healthpotions = data.healthpotions;
            gm.maxHealthpotions = data.maxHealthpotions;
            gm.chest_of_everlasting_wealth = data.chestLooted;
            Destroy(this.gameObject);
        }
    }

}
