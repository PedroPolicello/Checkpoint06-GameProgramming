using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSystemTimesUp : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;

    [Header("GameObjects")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameObject timesUp;
    [SerializeField] private GameObject cutsceneSystem;

    void Start()
    {
        menuButton.onClick.AddListener(Menu);
        exitButton.onClick.AddListener(ExitGame);
    }

    void Menu()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void ExitGame()
    {
        Debug.LogError("Quit");
        Application.Quit();
    }
}
