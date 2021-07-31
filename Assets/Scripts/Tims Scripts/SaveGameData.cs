using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameData
{
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
