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
    private Quest quest;
    [SerializeField]
    private Player player;



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
    }



}
