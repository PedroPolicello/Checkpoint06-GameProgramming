using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{

    [SerializeField] private float totalTime = 120;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timesUpScreen;
    private float time;


    void Update()
    {
        time += Time.deltaTime;
        float remainingTime = totalTime - time;


        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        string minutesString = minutes.ToString("D2");
        string secondsString = seconds.ToString("D2");

        timerText.text = (minutesString + ":" + secondsString);

        if (remainingTime <= 0)
        {
            Time.timeScale = 0;
            timerText.text = "00:00";
            timesUpScreen.SetActive(true);
        }

    }

}