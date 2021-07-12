using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponswitch : MonoBehaviour
{
    ShootArrows shootArrows;
    public GameObject[] Weapons;
    public KeyCode SwitchWeaponKey = KeyCode.Mouse2;
    private int activeweapon;
    private float speed;
    private Hero hero;
    private GameManager gamemanager;

        private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        hero = FindObjectOfType<Hero>();
        speed = hero.moveSpeed;
        shootArrows = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ShootArrows>();
        activeweapon = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(SwitchWeaponKey)&&Weapons.Length > 1) 
        {
            hero.moveSpeed = speed;
            if (activeweapon >= Weapons.Length-1)
            {
                Weapons[Weapons.Length - 1].SetActive(false);
                activeweapon = 0;
                Weapons[activeweapon].SetActive(true);
                shootArrows.enabled = false;
            }
            else 
            {
                if(gamemanager.bow_bought)
                { 
                 Weapons[activeweapon].SetActive(false);
                 activeweapon++;
                 Weapons[activeweapon].SetActive(true);
                 shootArrows.enabled = true;
                }
            }
            
        }
    }
}
