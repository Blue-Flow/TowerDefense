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
        SceneManager.LoadScene("Initialization");
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
    }

    public void LoadStoryMode(LevelDataSO levelData)
    {
        SceneManager.UnloadSceneAsync("MenuScene");
        SceneManager.LoadScene("StoryScene", LoadSceneMode.Additive);
        EventHandler.StartStoryMode(levelData);
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
        // play SFX
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LooseScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("StoryScene");
        Time.timeScale = 1;
    }
    private IEnumerator WaitForTime(Action methodToRun)
    {
       yield return new WaitForSeconds(timeToWait);
       methodToRun();
    }
    private IEnumerator LoadEndScreen_Win()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("WinScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("StoryScene");
        Time.timeScale = 1;
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
