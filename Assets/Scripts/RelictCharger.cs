using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelictCharger : MonoBehaviour
{
    Hero hero; // Verknüpfung mit Hero

    public GameObject leftTrigger;
    public GameObject rightTrigger;
    public GameObject botTrigger;
    public GameObject topTrigger;

    void Start()
    {
        hero = FindObjectOfType<Hero>();
    }

    void DestroyTrigger()
    {
        Destroy(leftTrigger);
        Destroy(rightTrigger);
        Destroy(botTrigger);
        Destroy(topTrigger);
    }   

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //healthBar.SetMaxHealth(hero.maxHp);
            hero.LoadRelictChargeBar(1);
            DestroyTrigger();
        }
    }
}
