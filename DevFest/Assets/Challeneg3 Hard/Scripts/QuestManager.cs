using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI newTask;
    [SerializeField]
    private GameObject QuestPhone;
    private Move move;

    [SerializeField]
    private TextMeshProUGUI description, money, exp, completion;

    [SerializeField]
    private Player player;

    private int counter;    



    private void Start()
    {
        QuestPhone.SetActive(false);
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
    }

    public void OpenPhone()
    {
        move.enabled = false;
        QuestPhone.SetActive(true);
        newTask.text = "";
    }
    public void ClosePhone()
    {

        QuestPhone.SetActive(false);
        move.enabled = true;
        description.text = "";
        money.text = "";
        exp.text = "";
        completion.text = "";
        counter = 0;

    }

    public void ShowQuestst1()
    {
        if(counter == 0)
        {
            description.text = player.quests[0].description;
            money.text += player.quests[0].moneyAmount.ToString();
            exp.text += player.quests[0].expAmount.ToString();
            completion.text += player.quests[0].goal.GetFound();
        }
        counter++;
    }

    public void ShowQuestst2()
    {
        if(counter == 0)
        {
            description.text = player.quests[1].description;
            money.text += player.quests[1].moneyAmount.ToString();
            exp.text += player.quests[1].expAmount.ToString();
            completion.text += player.quests[1].goal.GetFound().ToString();
        }
        counter++;
    }

    public void ShowQuestst3()
    {
        if(counter == 0)
        {
            description.text = player.quests[2].description;
            money.text = player.quests[2].moneyAmount.ToString();
            exp.text = player.quests[2].expAmount.ToString();
            completion.text = player.quests[0].goal.GetCurent().ToString();
        }
        counter++;
       


    }

   
}
