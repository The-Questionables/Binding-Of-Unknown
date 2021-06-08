using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // veränderbar durch Quest Giver Script/ Object
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if(goalType == GoalType.Kill)
        currentAmount++;
    }

    public void HeroHeal()
    {
        if(goalType == GoalType.RestoreHP)
        currentAmount++;
    }
}

public enum GoalType
{
    Kill,
    RestoreHP
}
