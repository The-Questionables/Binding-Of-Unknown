using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Melee : MonoBehaviour
{
    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Slime_Const.Tag_Enemy))
        {
            other.gameObject.GetComponent<EnemyStandart>().TakeDamage(gm.swordDamage);

        }
        if (other.gameObject.CompareTag("Barrel"))
        {
            other.gameObject.GetComponent<Barrel>().TakeDamage(gm.swordDamage);

        }
    }
}
