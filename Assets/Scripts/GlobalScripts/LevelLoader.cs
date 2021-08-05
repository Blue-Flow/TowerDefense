using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private int timeToWait = 3;
    private int currentSceneIndex;

    private void Awake()
    {
        EventsSubscribe();
    }
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
        else return;
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }
    private void LoadWinScreen()
    {
        StartCoroutine(WaitForTime_Win());
    }
    private void LoadLooseScreen()
    {
        StartCoroutine(nameof(LoadEndScreen_Loose));
    }
    private IEnumerator LoadEndScreen_Loose()
    {
        Time.timeScale = 0.2f;
        // play SFX
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LooseScreen");
        Time.timeScale = 1;
    }
    private IEnumerator WaitForTime()
    {
       yield return new WaitForSeconds(timeToWait);
       LoadNextScene();
    }
    private IEnumerator WaitForTime_Win()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("WinScreen");
    }
    private void EventsSubscribe()
    {
        EventHandler.OnWinGame += LoadWinScreen;
        EventHandler.OnLooseGame += LoadLooseScreen;
    }
    private void OnDestroy()
    {
        EventHandler.OnWinGame -= LoadWinScreen;
        EventHandler.OnLooseGame -= LoadLooseScreen;
    }
}
