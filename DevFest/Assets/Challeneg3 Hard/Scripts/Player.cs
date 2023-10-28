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
    public int curentQUest;

    private void Update()
    {
        quests[curentQUest].goal.Isreached();
    }

    private void Start()
    {
        exp = 0;
        level = 1;
        curentQUest = 0;
        quests.Add(NPC.quest[0]);
        quests[0].isActive = true;
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
        if (exp >= nextLevelXP)
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
        if (collision.gameObject.CompareTag("Weapon1"))
        {
            ReachedPlace();
            Debug.Log("Quest2");
        }
    }
    public void ReachedPlace()
    {
        if (quests[curentQUest].goal.goaltype == GoalType.Finding && quests[curentQUest].isActive == true)
        {
          
            LevelUp(quests[curentQUest].expAmount);
            IncreseMoney(quests[curentQUest].moneyAmount);
            quests[curentQUest].goal.SetFound();
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
