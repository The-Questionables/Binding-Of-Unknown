using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuOpener : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameManager gamemanager;

    public int getHealpotions = 1;
    public int healthRecoverBonus = 5;

    public bool isPlayerInRange;
    public bool isHealportUp;

    public GameObject buyItemt1Button;
    public GameObject takenItemt1Button;

    public GameObject buyItemt2Button;
    public GameObject takenItem2Button;

    public GameObject buyItemt3Button;
    public GameObject takenItemt3Button;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange == true)
        {
            ShopMenu.SetActive(true);
        }
        if (isPlayerInRange == false)
        {
            ShopMenu.SetActive(false);
        }

        if (gamemanager.isHealpotionCollectable == false)
        {
            buyItemt1Button.SetActive(false);
            takenItemt1Button.SetActive(true);
        }
        else
        {
            buyItemt1Button.SetActive(true);
            takenItemt1Button.SetActive(false);
        }

        if (isHealportUp)
        {
            buyItemt2Button.SetActive(false);
            takenItem2Button.SetActive(true);
        }
        else
        {
            buyItemt2Button.SetActive(true);
            takenItem2Button.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    public void BuyHealthpotion()
    {
        if(gamemanager.isHealpotionCollectable && gamemanager.coins >= 25)
        {
            gamemanager.healthpotions += getHealpotions;
            gamemanager.coins -= (25);
        }
    }

    public void PotionRecipeUpgrade()
    {
        if (!isHealportUp && gamemanager.coins >= 100)
        {
            gamemanager.healthRecover += healthRecoverBonus;
            gamemanager.coins -= (100);
            isHealportUp = true;
        }
    }

    public void UnlockBow()
    {
        if (gamemanager.coins >= 100 && gamemanager.bow_bought != true)
        {
            gamemanager.coins -= (100);
            gamemanager.bow_bought = true;
        }
    }
}
