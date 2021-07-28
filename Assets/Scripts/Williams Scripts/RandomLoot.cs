using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Amount Of Nothing That u want to Add to The List")]
    private int ChanceForNothing;
    public GameObject[] LootList; // Array an Items
    private int random; // speichert kurz zuf�lligen Wert aus dem Array
    private int random2;
    private bool lootSpawned = false; // sorgt daf�r das R�ume nicht gleichzeitig spawnen
    public bool Drop_Multiple = false;
    [SerializeField]
    private uint amount;

    public void LootSpawn()
    {
        if (lootSpawned == false && Drop_Multiple == false)
        {
            random2 = Random.Range(0, (ChanceForNothing + LootList.Length+1));
            if (random2 > ChanceForNothing)
            {
                random = Random.Range(0, LootList.Length); // Sucht zuf�lligen L�ngenwert des BottomRoom Arrays aus
                Instantiate(LootList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen
            }
        }
        else if (lootSpawned == false && Drop_Multiple == true)
        {
            if (amount == 0)
            {
                lootSpawned = true;
            }
            while (amount >= 1)
            {
                random2 = Random.Range(0, (ChanceForNothing + LootList.Length + 1));
                if (random2 > ChanceForNothing)
                {
                    random = Random.Range(0, LootList.Length);
                    Instantiate(LootList[random], transform.position, Quaternion.identity);
                    amount--;
                }
                else
                {
                    ChanceForNothing--;
                    amount--;
                }
            }
        }
        lootSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }
}