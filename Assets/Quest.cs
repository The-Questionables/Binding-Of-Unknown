using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // veränderbar durch Quest Giver Script/ Object
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
 // public int experienceReward;
    public int goldReward;
}
