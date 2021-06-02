using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuOpener : MonoBehaviour
{
    public bool isPlayerInRange;
    public GameObject UpgradeMenu;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange == true)
        {

            UpgradeMenu.SetActive(true);
        }
        if (isPlayerInRange == false)
        {
            UpgradeMenu.SetActive(false);
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
