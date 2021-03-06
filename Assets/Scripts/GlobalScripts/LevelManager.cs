using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LevelDataSO data;
    private int numberOfSpawnedAttacker = 0;
    private int numberOfDeadAttacker = 0;

    private void SetStoryModeData(LevelDataSO levelData)
    {
        data = levelData;
        SetLevelValues();
        EventHandler.ResourceValueChanged(data.startingSerenityAmount);
        StartCoroutine(nameof(WaitForTimeThenLaunch));
    }
    private IEnumerator WaitForTimeThenLaunch()
    {
        yield return new WaitForSeconds(data.initialSpawnDelay);
        EventHandler.StartGame();
    }
    private void SetLevelValues()
    {
        TryGetComponent(out Spawner spawner);
        if (spawner)
            spawner.SetSpawnerInfo(data.minSpawnDelayInSec, data.maxSpawnDelayInSec, data.activeSpawnPoints, data.enemiesToSpawn);
        else
            Debug.Log("No component Spawner found during initialization");

        TryGetComponent(out PlayerHealthManager playerHealthManager);
        if (playerHealthManager)
            playerHealthManager.SetHealth(data.numberOfLives);
        else
            Debug.Log("No component PlayerHealthManager found during initialization");
        
        FindObjectOfType<PlayerHealthDisplay>().SetLiveDisplaySettings(data.numberOfLives);

        FindObjectOfType<DefenderSpawner>().SetSerenityAmount(data.startingSerenityAmount);

        FindObjectOfType<DefenderButtonsDisplay>().SetDefenderButtons(data.defenderList);

    }
    private void UpdateCurrentLevelProgression()
    {
        float currentProgression = (float) numberOfDeadAttacker / (float) data.numberOfEnemies;
        EventHandler.LevelProgressionValueChange(currentProgression);
    }
    private void CountAttackerKilled()
    {
        numberOfDeadAttacker++;
        UpdateCurrentLevelProgression();
        if (numberOfDeadAttacker == data.numberOfEnemies)
        {
            EventHandler.WinGame(data.levelID);
        }
    }
    private void CountAttackerSpawned()
    {
        numberOfSpawnedAttacker++;
        if (numberOfSpawnedAttacker >= data.numberOfEnemies)
        {
            EventHandler.SpawnCapReached();
        }
    }
    #region events
    private void OnEnable()
    {
        EventHandler.OnAttackerDie += CountAttackerKilled;
        EventHandler.OnAttackerSpawned += CountAttackerSpawned;
        EventHandler.OnStartStoryMode += SetStoryModeData;
    }

    private void OnDisable()
    {
        EventHandler.OnAttackerDie -= CountAttackerKilled;
        EventHandler.OnAttackerSpawned -= CountAttackerSpawned;
        EventHandler.OnStartStoryMode -= SetStoryModeData;
        
    }
    #endregion
}
