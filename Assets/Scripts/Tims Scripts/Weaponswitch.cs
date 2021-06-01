using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponswitch : MonoBehaviour
{   
    public GameObject[] Weapons;
    public KeyCode SwitchWeaponKey = KeyCode.Mouse2;
    private int activeweapon;
    private int i;


    private void Start()
    {
        activeweapon = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(SwitchWeaponKey)&&Weapons.Length > 1) 
        {
            if (activeweapon >= Weapons.Length-1)
            {
                Weapons[Weapons.Length - 1].SetActive(false);
                activeweapon = 0;
                Weapons[activeweapon].SetActive(true);
            }
            else 
            {
                if(i<=0)
                { 
                 Weapons[activeweapon].SetActive(false);
                 activeweapon++;
                 Weapons[activeweapon].SetActive(true);
                }
            }
            
        }
    }
}
