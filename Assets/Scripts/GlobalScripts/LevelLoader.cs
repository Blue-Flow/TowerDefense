using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private int timeToWait = 3;
    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime(LoadMenu));
        }
        else return;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadStoryMode(LevelDataSO levelData)
    {
        SceneManager.LoadScene("StoryScene", LoadSceneMode.Additive);
        StartCoroutine(WaitForTimeThenEvent(levelData));
    }
    private void LoadWinScreen()
    {
        StartCoroutine(nameof(LoadEndScreen_Win));
    }
    private void LoadLooseScreen()
    {
        StartCoroutine(nameof(LoadEndScreen_Loose));
    }
    private IEnumerator LoadEndScreen_Loose()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LooseScene");
        Time.timeScale = 1;
    }
    private IEnumerator WaitForTime(Action methodToRun)
    {
       yield return new WaitForSeconds(timeToWait);
       methodToRun();
    }
    private IEnumerator WaitForTimeThenEvent(LevelDataSO levelData)
    {
        yield return new WaitForSeconds(1);
        EventHandler.StartStoryMode(levelData);
        SceneManager.UnloadSceneAsync("MenuScene");
    }
    private IEnumerator LoadEndScreen_Win()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("WinScene");
    }
    private void OnEnable()
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
