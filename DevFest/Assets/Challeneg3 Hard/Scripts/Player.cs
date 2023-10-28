using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health, money, level, exp, nextLevelXP;

    public List<Quest> quests;
    [SerializeField]
    private QuestGiver NPC;
    private int curentQUest;
    


    private void Start()
    {
        exp = 0;
        level = 1;
        curentQUest = 0;
        quests.Add(NPC.quest[0]);
    }

    public int GetIndex()
    {
        return curentQUest;
    }


    public void IncreseMoney(int amount)
    {
        money += amount;
    }

    public void LevelUp(int expaAmount)
    {
        exp += expaAmount;
        if (exp > nextLevelXP)
        {
            level++;
            nextLevelXP *= 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PNG"))
        {
            ReachedPlace();
        }
    }
    public void ReachedPlace()
    {
        if (quests[curentQUest].goal.goaltype == GoalType.FInding && quests[curentQUest].isActive== true)
        {
            StartCoroutine(quests[curentQUest].goal.SetFound());
            quests[curentQUest].isActive = false;
            Debug.Log("Reached");

        }
    }




    public int getMoney()
    {
        return money;
    }

    public int GetHealth()
    {
        return health;
    }

}
