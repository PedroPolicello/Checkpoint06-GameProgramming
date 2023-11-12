using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSystemPause : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;

    [Header("GameObjects")]
    [SerializeField] private GameObject pause;


    void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void ResumeGame()
    {
        pause.SetActive(false);
        Time.timeScale = 1;

    }

    void ExitGame()
    {
        Debug.LogError("Quit");
        Application.Quit();
    }
}
