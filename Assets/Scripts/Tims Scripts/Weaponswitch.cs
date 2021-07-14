using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weaponswitch : MonoBehaviour
{
    ShootArrows shootArrows;
    public GameObject[] Weapons;
    public KeyCode SwitchWeaponKey = KeyCode.Mouse2;
    private int activeweapon;
    private float speed;
    private Hero hero;
    private GameManager gamemanager;

    [Header("WeaponSwitch UI:")]
    public Image sword;
    public Image bow;
    public Image switchWeaponMouse;
    public Text switchWeaponText;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        hero = FindObjectOfType<Hero>();
        speed = hero.moveSpeed;
        shootArrows = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ShootArrows>();
        activeweapon = 0;

        // UI Images
        sword.enabled = false;
        bow.enabled = false;
        switchWeaponMouse.enabled = false;
        switchWeaponText.enabled = false;
    }

    void Update()
    {
        if(gamemanager.bow_bought)
        {
            bow.enabled = true;
            switchWeaponMouse.enabled = true;
            switchWeaponText.enabled = true;
        }

        if (Input.GetKeyDown(SwitchWeaponKey)&&Weapons.Length > 1) 
        {
            hero.moveSpeed = speed;
            if (activeweapon >= Weapons.Length-1)
            {
                Weapons[Weapons.Length - 1].SetActive(false);
                activeweapon = 0;
                Weapons[activeweapon].SetActive(true);
                shootArrows.enabled = false;

                sword.enabled = false;
                bow.enabled = true;
            }
            else 
            {
                if(gamemanager.bow_bought)
                { 
                    Weapons[activeweapon].SetActive(false);
                    activeweapon++;
                    Weapons[activeweapon].SetActive(true);
                    shootArrows.enabled = true;

                    sword.enabled = true;
                    bow.enabled = false;
                }
            }
            
        }
    }
}
