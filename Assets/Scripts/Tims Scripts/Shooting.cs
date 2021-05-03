using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Arrow;
    public Transform Arrowspawnpoint;
    public KeyCode shoot = KeyCode.Mouse0;
    public float Firerate = 0.75f;
    private float counter;
    private float fireratetimer;

    private void Start()
    {
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
                Instantiate(Arrow, Arrowspawnpoint.position, Arrowspawnpoint.rotation);
                fireratetimer = Firerate;
            }
        }
    }


}
