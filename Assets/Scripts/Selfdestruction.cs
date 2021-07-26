using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruction : MonoBehaviour
{
    public int destroyTime = 15;


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
