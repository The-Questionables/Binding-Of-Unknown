using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameData
{
    //
    public Quest1 quest1;
    public Quest2 quest2;
    public Quest3 quest3;
    //
    public float enemyCounter;
    public float healCounter;
    //
    public bool screen_shake_active;
    public bool chestLooted;
    public bool bow;
    public int coins;
    public int health;
    public int healthpotions;
    public int maxHealth;
    public int maxHealthpotions;
    public string level;
    public float[] position;

    public SaveGameData(GameManager gm)
    {
        //
        quest1 = gm.quest1;
        quest2 = gm.quest2;
        quest3 = gm.quest3;
        //
        healCounter = gm.healCounter;
        enemyCounter = gm.enemyCounter;
        //
        screen_shake_active = gm.Screenshake;
        bow = gm.bow_bought;
        level = gm.ActiveScene;
        coins = gm.coins;
        health = gm.hp;
        healthpotions = gm.healthpotions;
        maxHealth = gm.maxHp;
        maxHealthpotions = gm.maxHealthpotions;
        chestLooted = gm.chest_of_everlasting_wealth;
    }
}
