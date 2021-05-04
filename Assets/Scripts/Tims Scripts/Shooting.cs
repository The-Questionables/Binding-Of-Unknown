using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Arrow;
    public Transform Arrowspawnpoint;
    public KeyCode shoot = KeyCode.Mouse0;
    public float newMovespeed;
    public float Firerate = 0.75f;
    public Hero George;
    private float speed;
    private float fireratetimer;

    private void Start()
    {
        George = FindObjectOfType<Hero>();
        speed = George.moveSpeed;
        fireratetimer = Firerate;
    }
    public void Update()
    {
        fireratetimer -= Time.deltaTime;
        Shoot();
    }

    public void Shoot() 
    {
        if (fireratetimer <= 0)
        {
            if (Input.GetKey(shoot))
            {
                George.moveSpeed = newMovespeed;
                Instantiate(Arrow, Arrowspawnpoint.position, Arrowspawnpoint.rotation);
                fireratetimer = Firerate;
            }
        }
        else 
        {
            if (fireratetimer >= 0) 
            {
                George.moveSpeed = speed;
            }
        }
    }


}
