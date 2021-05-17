using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameData
{
    public int coins;
    public int health;
    public int healthpotions;
    public int maxHealth;
    public int maxHealthpotions;
    public string level;
    public float[] position;

    public SaveGameData(GameManager gm)
    {
        level = gm.ActiveScene;
        coins = gm.coins;
        health = gm.hp;
        healthpotions = gm.healthpotions;
        maxHealth = gm.maxHp;
        maxHealthpotions = gm.maxHealthpotions;
    }
}
