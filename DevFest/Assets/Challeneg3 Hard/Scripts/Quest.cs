using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Quest
{

    public bool isActive;
    public string title;
    public string description;
    public int moneyAmount;
    public int expAmount;
    public Transform location;

    public QuestGoal goal;

    
}
