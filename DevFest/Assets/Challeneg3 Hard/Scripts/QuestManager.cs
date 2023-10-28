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
    private TextMeshProUGUI title, description, money, exp;
    [SerializeField]
    private Button quesButton;

    private int currenQUest;

    [SerializeField]
    private Quest quest;
    [SerializeField]
    private Player player;



    private void Start()
    {
        QuestPhone.SetActive(false);
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
        currenQUest = 0;
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
    }

    public void ShowQuests()
    {
        title.text = player.quests[currenQUest].title;
        description.text = player.quests[currenQUest].description;
        money.text = player.quests[currenQUest].moneyAmount.ToString();
        exp.text = player.quests[currenQUest].expAmount.ToString();
    }

}
