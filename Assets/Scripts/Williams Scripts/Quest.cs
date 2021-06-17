using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // veränderbar durch Quest Giver Script/ Object
public class Quest1
{
    public bool isActive;

         public string title;
         public string description;
    //   public int experienceReward;
         public int goldReward;

    public QuestGoal goal;

    public void CompleteQuest1()
    {
        isActive = false;
        Debug.Log(/*title*/"Quest 1 " + "was completed!");
    }

}

[System.Serializable] // veränderbar durch Quest Giver Script/ Object
public class Quest2
{
    public bool isActive;

    public string title;
    public string description;
    //   public int experienceReward;
    public int goldReward;

    public QuestGoal goal;

    public void CompleteQuest2()
    {
        isActive = false;
        Debug.Log(/*title*/"Quest 2 " + "was completed!");
    }

}

[System.Serializable] // veränderbar durch Quest Giver Script/ Object
public class Quest3
{
    public bool isActive;

    // public string title;
    // public string description;
    //   public int experienceReward;
    public int goldReward;

    public QuestGoal goal;

    public void CompleteQuest3()
    {
        isActive = false;
        Debug.Log(/*title*/"Quest 3 " + "was completed!");
    }

}
