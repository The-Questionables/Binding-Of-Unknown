using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    List<GameObject> itemsInDrop;
    int[] dropChance;

    private int totalDropChance;
    private int randomChance;

    public void GetLootDrop()
    {
        foreach (var chance in dropChance)
        {
            totalDropChance += chance;
        }

        randomChance = Random.Range(0, totalDropChance + 1);

        for (int i = 0; i < dropChance.Length; i++)
        {
            if (randomChance <= dropChance[i])
            {
                Debug.Log(itemsInDrop[i]);
                Instantiate(itemsInDrop[i], transform.position, Quaternion.identity);
                return;
            }
            else
            {
                randomChance -= dropChance[i];
            }
        }
    }
}