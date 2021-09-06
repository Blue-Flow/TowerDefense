using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private int timeToWait = 3;
    private LevelDataSO currentLevel;

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
    private void SetLevelData(LevelDataSO levelData)
    {
        MainManager.Instance.LastLoadedLevel = levelData;
    }
    public void ReloadStoryMode()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("StoryScene", LoadSceneMode.Additive);
        StartCoroutine(WaitForTimeThenEvent(MainManager.Instance.LastLoadedLevel, currentSceneIndex));
    }
    public void LoadStoryMode(LevelDataSO levelData)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SetLevelData(levelData);
        SceneManager.LoadScene("StoryScene", LoadSceneMode.Additive);
        StartCoroutine(WaitForTimeThenEvent(levelData, currentSceneIndex));
    }
    private void LoadWinScreen(int levelNumber)
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
    private IEnumerator WaitForTimeThenEvent(LevelDataSO levelData, int sceneIndexToUnload)
    {
        yield return new WaitForSeconds(1);
        EventHandler.StartStoryMode(levelData);
        SceneManager.UnloadSceneAsync(sceneIndexToUnload);
    }
    private IEnumerator LoadEndScreen_Win()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("WinScene");
    }
    #region events
    private void OnEnable()
    {
        EventHandler.OnWinGame += LoadWinScreen;
        EventHandler.OnLooseGame += LoadLooseScreen;
    }
    private void OnDisable()
    {
        EventHandler.OnWinGame -= LoadWinScreen;
        EventHandler.OnLooseGame -= LoadLooseScreen;
    }
    #endregion
}
