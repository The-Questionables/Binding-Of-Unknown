using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Sword : MonoBehaviour
{
    public int damage = 10;
    public float knockbackPower = 25;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyStandart>().TakeDamage(damage);

        }
    }
}
