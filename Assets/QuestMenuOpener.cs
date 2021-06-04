using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenuOpener : MonoBehaviour
{
    public bool isPlayerInRange;

    public GameObject QuestMenu;

    public Quest1 quest1;
    public Quest2 quest2;
    public Quest3 quest3;

    public GameManager gamemanager;

    public GameObject Quest1;
    public GameObject takeQuest1Button;
    public GameObject takenQuest1Button;

    public GameObject Quest2;
    public GameObject takeQuest2Button;
    public GameObject takenQuest2Button;

    public GameObject Quest3;
    public GameObject takeQuest3Button;
    public GameObject takenQuest3Button;

    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

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

    public void AcceptQuest1()
    {
        Quest1.SetActive(true);
        Quest2.SetActive(false);
        Quest3.SetActive(false);
        takeQuest1Button.SetActive(false);
        takenQuest1Button.SetActive(true);
        quest1.isActive = true;
        // give Player the Quest
        gamemanager.quest1 = quest1;
    }

    public void AcceptQuest2()
    {
        Quest1.SetActive(false);
        Quest2.SetActive(true);
        Quest3.SetActive(false);
        takeQuest2Button.SetActive(false);
        takenQuest2Button.SetActive(true);
        quest2.isActive = true;
        gamemanager.quest2 = quest2;
    }

    public void AcceptQuest3()
    {
        Quest1.SetActive(false);
        Quest2.SetActive(false);
        Quest3.SetActive(true);
        takeQuest3Button.SetActive(false);
        takenQuest3Button.SetActive(true);
        quest3.isActive = true;
        gamemanager.quest3 = quest3;
    }

    public void ResetQuests()
    {
        Quest1.SetActive(true);
        Quest2.SetActive(true);
        Quest3.SetActive(true);

        takeQuest1Button.SetActive(true);
        takenQuest1Button.SetActive(false);
        quest1.isActive = false;

        takeQuest2Button.SetActive(true);
        takenQuest2Button.SetActive(false);
        quest2.isActive = false;

        takeQuest3Button.SetActive(true);
        takenQuest3Button.SetActive(false);
        quest3.isActive = false;
    }

}
