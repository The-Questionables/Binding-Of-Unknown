using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopsystem : MonoBehaviour
{
    [Header("Upgrade Values:")]
    public int MaxHealthpotionUpgrade;
    public int MaxHealthUpgrade;
    public int SwordUpgrade;
    public int BowUpgrade;

    [Header("Costs:")]
    public int MaxHealthpotionUpgradeCost;
    public int MaxHealthUpgradeCost;
    public int SwordUpgradeCost;
    public int BowUpgradeCost;

    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void BuyPotionbelt()
    {
        if(gm.coins >=MaxHealthpotionUpgradeCost)
        {
            gm.maxHealthpotions += MaxHealthpotionUpgrade;
            gm.Coins -= MaxHealthpotionUpgradeCost;
        }
    }

    public void BuyMaxHealthUpgrade()
    {
        if (gm.coins >= MaxHealthUpgradeCost)
        {
            gm.maxHp += MaxHealthUpgrade;
            gm.coins -= MaxHealthUpgradeCost;
        }
    }

    public void BuySwordUpgrade()
    {
        if (gm.coins >= SwordUpgradeCost)
        {
            gm.swordDamage += SwordUpgrade;
            gm.coins -= SwordUpgradeCost;
        }
    }

    public void BuyBowUpgrade()
    {
        if (gm.coins >= BowUpgradeCost)
        {
            gm.bowDamage += BowUpgrade;
            gm.coins -= BowUpgradeCost;
        }
    }
}
