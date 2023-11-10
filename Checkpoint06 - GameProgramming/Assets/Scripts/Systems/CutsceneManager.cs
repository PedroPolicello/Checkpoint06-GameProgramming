using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager instance;

    [SerializeField] private GameObject cutsceneCam;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject timerSystem;
    [SerializeField] private GameObject SpawnerSystem;
    [SerializeField] private GameObject cutsceneBG;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        timerSystem.SetActive(false);
        SpawnerSystem.SetActive(false);
        cutsceneBG.SetActive(true);
    }

    public void Start()
    {
        SetCutsceneCamON();
        StartCoroutine(MovementEnd());
    }

    private void SetCutsceneCamON()
    {
        cutsceneCam.SetActive(true);
        mainCam.SetActive(false);
    }

    private void SetCutsceneCamOFF()
    {
        timerSystem.SetActive(true);
        SpawnerSystem.SetActive(true);
    }

    IEnumerator MovementEnd()
    {
        yield return new WaitForSeconds(5f);
        cutsceneCam.SetActive(false);
        mainCam.SetActive(true);
        cutsceneBG.SetActive(false);
        yield return new WaitForSeconds(2f);
        SetCutsceneCamOFF();
    }


}
