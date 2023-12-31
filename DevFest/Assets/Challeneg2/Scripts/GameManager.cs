using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI winingText;
    private int score = 0;
    [SerializeField]
    private int winingScore = 4;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private TextMeshProUGUI buttonText;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private Wire[] wire;

    [SerializeField]
    private float timerTime = 40f;
    private bool win;



    private void Start()
    {
        win = false;
        winingText.text = "";
        restartButton.image.enabled = false;
        buttonText.text = "";
        Invoke(nameof(Loose), timerTime);
        
    }

    public void scoring()
    {

        score++;
        if (score == winingScore)
        {
            Debug.Log("You won");
            winingText.text = "You Won!";
            restartButton.image.enabled = true;
            buttonText.text = "Restart";
            win = true;
            Destroy(timer);
        }   

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Loose()
    {
        if (!win)
        {
            winingText.text = "You Lost";
            restartButton.image.enabled = true;
            buttonText.text = "Restart";
            for (int i = 0; i < wire.Length; i++)
            {
                Destroy(wire[i]);
            }
        }
      
    }



}
