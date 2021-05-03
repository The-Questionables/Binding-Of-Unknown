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
        Shoot();
    }

    public void Shoot() 
    {
        if (Input.GetKey(shoot))
        {
            Debug.Log("Hat Funktioniert");
            Instantiate(Arrow, Arrowspawnpoint.position, Arrowspawnpoint.rotation);
        }
    }


}
