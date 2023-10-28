using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class QuestGoal
{
    public GoalType goaltype;
    [SerializeField]
    private int currentAmount, goalAmount;
    [SerializeField]
    private bool found = false;



    public bool Isreached()
    {
        return (currentAmount >= goalAmount);
    }

    public bool GetFound()
    {
        return found;
    }


    public void KillEnnemy()
    {

        if (goaltype == GoalType.Killing)
            currentAmount++;
    }

    public int GetCurent()
    {
        return currentAmount;
    }

    public void Gathering()
    {
        if (goaltype == GoalType.Gatherring)
        {
            currentAmount++;
        }
    }

    public void SetFound()
    {

        if (goaltype == GoalType.Finding )
        {
            found = true;  
        }



    }
}



public enum GoalType
{

    Killing,
    Gatherring,
    Finding,

}


