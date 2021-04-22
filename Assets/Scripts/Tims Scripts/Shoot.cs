using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameManager gm;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public GameObject ProjectilePrefab;
    public KeyCode shoot = KeyCode.Space;
    public float Cooldown = 0.75f;
    private float TimeTillReadyToShoot;


    public bool shoot1 = true;
    public bool shoot2 = false;
    public bool shootanimation = false;

    void Shoot3()
    {
        if (TimeTillReadyToShoot <= Cooldown)
        {
            TimeTillReadyToShoot = TimeTillReadyToShoot + Time.deltaTime;
        }
        if (TimeTillReadyToShoot >= Cooldown)
        {
            shooting();
            TimeTillReadyToShoot = TimeTillReadyToShoot - Cooldown;
        }
    }

    void Update()
    {

        shoot2 = Input.GetKey(shoot);

        /*if (shoot2 == true)
        {
            shooting();
        }= schuss ohne cooldown */
        if (TimeTillReadyToShoot <= Cooldown)
        {
            TimeTillReadyToShoot = TimeTillReadyToShoot + Time.deltaTime;
        }

        if (TimeTillReadyToShoot >= Cooldown && shoot2 == true)
        {
            shooting();
            TimeTillReadyToShoot = TimeTillReadyToShoot - Cooldown;
        }

        /*TimeTillReadyToShoot2 = TimeTillReadyToShoot2 + Time.deltaTime;

        if (TimeTillReadyToShoot2 >= TimeTillReadyToShoot && shoot2 == true)
        {
            shooting();
            TimeTillReadyToShoot2 = TimeTillReadyToShoot2 - TimeTillReadyToShoot;
        } = aufladender schuss
        */
        
    }


    void shooting()
    {
        if (gm.PlayerHitpoints > 0)
        {
            shootanimation = true;
            if (shoot1 == true)
            { 
                Instantiate(ProjectilePrefab, spawnPosition1.position, spawnPosition1.rotation);
                shoot1 = false;
            }
            else if (shoot1 == false)
            { 
                Instantiate(ProjectilePrefab, spawnPosition2.position, spawnPosition2.rotation);
                shoot1 = true;
            }
        }
    }
    //void fireBullet(Vector2 direction, float rotationZ)
    //{
    //    GameObject b = Instantiate(ProjectilePrefab) as GameObject;
    //    b.transform.position = bulletStart.transform.position;
    //    b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    //    b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    //}


}
