using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour     //Dialog Trigger
{
    private GameManager gm;
    public Dialog dialog;
    public bool OptionsFromGameManager;
    public bool playerInRange;
    [HideInInspector]
    public int health;
  


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {

            TriggerDialogue();

        }
        
        if(playerInRange == false)
        {
            FindObjectOfType<DialogManager>().ExitDialog(dialog);
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
       // playerInRange = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
