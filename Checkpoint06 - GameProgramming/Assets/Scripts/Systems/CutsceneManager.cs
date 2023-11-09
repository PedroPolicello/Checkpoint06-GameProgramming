using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cutsceneCam;
    [SerializeField] private GameObject mainCam;

    private void Start()
    {
        SetCutsceneCamON();
        StartCoroutine(MovementEnd());
    }

    private void Update()
    {
        CamMovementHandler();
    }

    private void SetCutsceneCamON()
    {
        cutsceneCam.SetActive(true);
        mainCam.SetActive(false);
    }

    private void SetCutsceneCamOFF()
    {
        cutsceneCam.SetActive(false);
        mainCam.SetActive(true);
    }

    private void CamMovementHandler()
    {
        cutsceneCam.transform.Translate(new Vector2(3f, 0) * Time.deltaTime);
    }

    IEnumerator MovementEnd()
    {
        yield return new WaitForSeconds(5f);
        SetCutsceneCamOFF();
    }


}
