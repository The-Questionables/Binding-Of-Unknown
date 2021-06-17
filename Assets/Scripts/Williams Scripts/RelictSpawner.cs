using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelictSpawner : MonoBehaviour
{
    public GameObject[] RelictList; // Array an Items
    private int random; // speichert kurz zuf�lligen Wert aus dem Array
    private bool lootSpawned = false; // sorgt daf�r das R�ume nicht gleichzeitig spawnen

    void Start()
    {
        Invoke("RelictSpawn", 0.2f); // aktiviert Methode mit einen Time delay
    }

    public void RelictSpawn()
    {
        if (lootSpawned == false) 
        {
            random = Random.Range(0, RelictList.Length); // Sucht zuf�lligen L�ngenwert des Arrays aus

            if (RelictList[random] == null)
            {
               random = Random.Range(0, RelictList.Length); // Sucht einen neuen zuf�lligen L�ngenwert des Arrays aus
            }
            Instantiate(RelictList[random], transform.position, Quaternion.identity); // Clonen eines Objektes und erstellen

            (RelictList[random]) = null; // l�scht das Gameobject aus dem Array aber nur in dieser Scene
            //colliderList.RemoveAll(item => item == null);
            // https://answers.unity.com/questions/854625/remove-object-from-list-after-gameobject-was-destr.html
        }
        lootSpawned = true; // setzt bool auf true damit keine weiteren Items spawnen
    }
}
