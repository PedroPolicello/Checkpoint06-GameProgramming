using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSystemMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    [Header("GameObjects")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameObject cutsceneSystem;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        gameplay.SetActive(true);
        cutsceneSystem.SetActive(true);
    }

    void ExitGame()
    {
        Debug.LogError("Quit");
        Application.Quit();
    }
}
