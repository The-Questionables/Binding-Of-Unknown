using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponRotation : MonoBehaviour
{
    public GameObject user;
    private GameObject target;
    void Start()

    {
       // user = GameObject.FindGameObjectWithTag("Enemy");
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - user.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        user.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
