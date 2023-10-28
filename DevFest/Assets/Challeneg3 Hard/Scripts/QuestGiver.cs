using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    
    public Quest[] quest;
    [SerializeField]
    private Player player;
    private int questIndex;

    [SerializeField]
    private Button[] questButton;
    [SerializeField]
    private TextMeshProUGUI[] buttonText;
    [SerializeField]
    private QuestArrow arrow;


    private void Start()
    {
        questIndex = 1;
        for (int i = 1; i < questButton.Length; i++)
        {
            questButton[i].image.enabled = false;
            buttonText[i].text = "";
        }
        questButton[0].enabled = true;
        buttonText[0].text = player.quests[0].title;

    }

    public void GiveQuest()
    {
        if (quest[questIndex].isActive == false)
        {
            quest[questIndex].isActive = true;
            player.quests.Add(quest[questIndex]);
            questButton[questIndex].image .enabled= true;
            buttonText[questIndex].text = player.quests[questIndex].title;
            arrow.target = quest[questIndex].location;
        }
        if (quest[questIndex].goal.Isreached() || quest[questIndex].goal.GetFound() )
        {
            questIndex++;
        }
        
    }

    
}
