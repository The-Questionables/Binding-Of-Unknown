using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameManager gm;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public GameObject template;
    public KeyCode shoot = KeyCode.Space;
    public float Cooldown = 0.75f;
    public float Firerate;
    public float Minigunspeed = 1.5f;
    public float dauer = 10f;
    private float counter;
    public bool shoot1 = true;
    public bool shoot2 = false;
    public bool shootanimation = false;

    void Start()
    {
        counter = dauer;
    } 

    void Shoot3()
    {
        if (Firerate <= Cooldown)
        {
            Firerate = Firerate + Time.deltaTime;
        }
        if (Firerate >= Cooldown)
        {
            shooting();
            Firerate = Firerate - Cooldown;
        }
    }

    void Update()
    {

        shoot2 = Input.GetKey(shoot);

        /*if (shoot2 == true)
        {
            shooting();
        }= schuss ohne cooldown */
        if (Firerate <= Cooldown)
        {
            Firerate = Firerate + Time.deltaTime;
        }

        if (Firerate >= Cooldown && shoot2 == true)
        {
            shooting();
            Firerate = Firerate - Cooldown;
        }

        /*Firerate2 = Firerate2 + Time.deltaTime;

        if (Firerate2 >= Firerate && shoot2 == true)
        {
            shooting();
            Firerate2 = Firerate2 - Firerate;
        } = aufladender schuss
        */
        
    }
    void Minigun()
    { Cooldown /= Minigunspeed; }


    void shooting()
    { if (gm.PlayerHitpoints > 0)
        {
            shootanimation = true;
            if (shoot1 == true)
        { 
            Instantiate(template, spawnPosition1.position, spawnPosition1.rotation);
            shoot1 = false;
        }
        else if (shoot1 == false)
        { 
            Instantiate(template, spawnPosition2.position, spawnPosition2.rotation);
            shoot1 = true;
        }
        }
    }

    public IEnumerator Countdown()
        {
        counter = dauer;
        Minigun();
        while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
        if (counter <= 0.0f) { Cooldown *= Minigunspeed; } 
        }

}
