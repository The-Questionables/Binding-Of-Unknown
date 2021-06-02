using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Sword : MonoBehaviour
{

    public float knockbackPower = 25;

    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyStandart>().TakeDamage(gm.swordDamage);

        }
    }
}
