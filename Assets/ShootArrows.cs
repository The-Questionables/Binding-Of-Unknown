using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrows : MonoBehaviour
{
    [Header("Arrows:")]
    public GameObject Arrow;
    public Transform Arrowspawnpoint;
    public KeyCode shoot = KeyCode.Mouse0;
    public float newMovespeed;
    public float Firerate = 0.75f;
    public float slowdowntimer = 2f;
    private float speed = 4f;
    private float fireratetimer;
    private float delay;
    private bool isSlowed = false;
    // Verweis
    private Hero hero;

    private void Start()
    {
        hero = FindObjectOfType<Hero>();
        speed = hero.moveSpeed;
        fireratetimer = Firerate;
        delay = slowdowntimer;
    }
    public void Update()
    {
        if (isSlowed == true) 
        {
            delay -= Time.deltaTime;
        }
        fireratetimer -= Time.deltaTime;
        Shoot();
    }

    public void Shoot()
    {
        if (fireratetimer <= 0)
        {
            if (Input.GetKey(shoot))
            {
                hero.moveSpeed = newMovespeed;
                isSlowed = true;
            }
            if (delay <= 0 && isSlowed==true)
            {
                Instantiate(Arrow, Arrowspawnpoint.position, Arrowspawnpoint.rotation);
                fireratetimer = Firerate;
                delay = slowdowntimer;
                hero.moveSpeed = speed;
                isSlowed = false;
            }
        }
    }


}

// Altes Script
/*
{
    [Header("Arrows:")]
    public Transform fireSpawn;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 0.9f;
    private float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoota();
        }
    }

    private void Shoota()
    {
        GameObject bullet = Instantiate(bulletPrefab, fireSpawn.position, fireSpawn.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(fireSpawn.up * bulletForce, ForceMode2D.Impulse);
    }
}

*/

