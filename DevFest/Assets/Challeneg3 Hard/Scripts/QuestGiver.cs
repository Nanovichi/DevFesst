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


    private void Start()
    {
        questIndex = 0;
        
    }

    public void GiveQuest()
    {
        if (quest[questIndex].isActive == false)
        {
            quest[questIndex].isActive = true;
            player.quests.Add(quest[questIndex]);
            questButton[questIndex].enabled = true;
            buttonText[questIndex].text = player.quests[questIndex].title;

        }
        if (quest[questIndex].goal.Isreached())
        {
            questIndex++;
        }
        
    }

    
}
