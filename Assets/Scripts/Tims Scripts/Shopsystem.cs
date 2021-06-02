using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopsystem : MonoBehaviour
{
    public int MaxHealthpotionUpgrade;
    public int MaxHealthUpgrade;
    public int SwordUpgrade;
    public int BowUpgrade;

    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void BuyPotionbelt()
    {
        gm.maxHealthpotions += MaxHealthpotionUpgrade;
    }
    public void BuyMaxHealthUpgrade()
    {
        gm.maxHp += MaxHealthUpgrade;
    }
    public void BuySwordUpgrade()
    {
        gm.swordDamage += SwordUpgrade;
    }
    public void BuyBowUpgrade()
    {
        gm.bowDamage += SwordUpgrade;
    }
}
