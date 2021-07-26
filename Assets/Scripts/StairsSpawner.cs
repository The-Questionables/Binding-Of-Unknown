using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsSpawner : MonoBehaviour
{
    public GameObject stairs;
    public int enemyAmount;

    private void Update()
    {
        if(enemyAmount == 0)
        {
            stairs.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            stairs.SetActive(false);
            enemyAmount++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyAmount--;
        }

    }

}
