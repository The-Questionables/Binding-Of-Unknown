using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
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

    public bool isMaxHealthPotionUp = false;
    public bool isMaxHealthUp = false;
    public bool isSwordUp = false;
    public bool isBowUp = false;

    public GameObject buyButton1;
    public GameObject takenButton1;

    public GameObject buyButton2;
    public GameObject takenButton2;

    public GameObject buyButton3;
    public GameObject takenButton3;

    public GameObject buyButton4;
    public GameObject takenButton4;

    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if (isMaxHealthUp)
        {
            buyButton1.SetActive(false);
            takenButton1.SetActive(true);
        }
        else
        {
            buyButton1.SetActive(true);
            takenButton1.SetActive(false);
        }

        if (isMaxHealthPotionUp)
        {
            buyButton2.SetActive(false);
            takenButton2.SetActive(true);
        }
        else
        {
            buyButton2.SetActive(true);
            takenButton2.SetActive(false);
        }

        if (isSwordUp)
        {
            buyButton3.SetActive(false);
            takenButton3.SetActive(true);
        }
        else
        {
            buyButton3.SetActive(true);
            takenButton3.SetActive(false);
        }

        if (isBowUp)
        {
            buyButton4.SetActive(false);
            takenButton4.SetActive(true);
        }
        else
        {
            buyButton4.SetActive(true);
            takenButton4.SetActive(false);
        }
    }

    public void BuyPotionbelt()
    {
        if(gm.coins >=MaxHealthpotionUpgradeCost)
        {
            gm.maxHealthpotions += MaxHealthpotionUpgrade;
            gm.coins -= MaxHealthpotionUpgradeCost;
            isMaxHealthPotionUp = true;
        }
    }

    public void BuyMaxHealthUpgrade()
    {
        if (gm.coins >= MaxHealthUpgradeCost)
        {
            gm.maxHp += MaxHealthUpgrade;
            gm.coins -= MaxHealthUpgradeCost;

            isMaxHealthUp = true;
        }
    }

    public void BuySwordUpgrade()
    {
        if (gm.coins >= SwordUpgradeCost)
        {
            gm.swordDamage += SwordUpgrade;
            gm.coins -= SwordUpgradeCost;
            isSwordUp = true;
        }
    }

    public void BuyBowUpgrade()
    {
        if (gm.coins >= BowUpgradeCost)
        {
            gm.bowDamage += BowUpgrade;
            gm.coins -= BowUpgradeCost;
            isBowUp = true;
        }
    }
}
