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
    private bool found;



    public bool Isreached()
    {
        return (currentAmount >= goalAmount);
    }



    public void KillEnnemy()
    {

        if (goaltype == GoalType.Killing)
            currentAmount++;
    }

    public void Gathering()
    {
        if (goaltype == GoalType.Gatherring)
        {
            currentAmount++;
        }
    }

    public IEnumerator SetFound()
    {

        if (goaltype == GoalType.FInding)
        {
            found = true;
            yield return new WaitForSeconds(2f);
            found=false;    

        }



    }
}



public enum GoalType
{

    Killing,
    Gatherring,
    FInding,

}


