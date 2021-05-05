using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponRotation : MonoBehaviour
{
    private GameObject user;
    private GameObject target;
    void Start()

    {
        user = GameObject.FindGameObjectWithTag("Enemy");
        target = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = target.transform.position - user.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
