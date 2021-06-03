using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuOpener : MonoBehaviour
{
    public bool isPlayerInRange;
    public GameObject QuestMenu;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange == true)
        {

            QuestMenu.SetActive(true);
        }
        if (isPlayerInRange == false)
        {
            QuestMenu.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
