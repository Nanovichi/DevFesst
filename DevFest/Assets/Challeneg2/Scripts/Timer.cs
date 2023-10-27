using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private int durration;

    private int remainingDuration;

    private void Start()
    {
        Begin(durration);
    }

    private void Begin(int seconds)
    {
        remainingDuration = seconds;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            text.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }

        onEnd();
    }

    private void onEnd()
    {
        print("End");
    }


}
