//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class Timer : MonoBehaviour
//{
//    [Header("Component")]
//    public TextMeshProUGUI timerText;

//    [Header("Timer Settings")]
//    public float currentTime;
//    public bool countDown;

//    [Header("Limit Settings")]
//    public bool hasLimit;
//    public float timerLimit;



//    // Update is called once per frame
//    void Update()
//    {
//        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

//        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit )))
//        {
//            currentTime = timerLimit;
//            SetTimerText();
//            timerText.color = Color.yellow;
//            enabled = false;
//        }

//        SetTimerText();

//    }

//    private void SetTimerText()
//    {
//        timerText.text = "Time Left: " + currentTime.ToString("0.0");
//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Game Over Settings")]
    public bool timeOver;
    public NameClickHandler clickHandler;


    // Update is called once per frame
    void Update()
    {


        if (!timeOver)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

            if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
            {
                currentTime = timerLimit;
                SetTimerText();
                timerText.color = Color.yellow;
                enabled = false;
            }

            if (currentTime <= 0f)
            {
                timeOver = true;
                SetTimerText();
                ShowTimeOverMessage();
            }

            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        timerText.text = "Time: " + currentTime.ToString("0.0");
    }

    public void ShowTimeOverMessage()
    {
        Debug.Log("Time ran out, Try again!");
    }
}