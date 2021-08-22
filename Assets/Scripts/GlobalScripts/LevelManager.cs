using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelDataSO data;
    private int numberOfSpawnedAttacker = 0;
    private int numberOfDeadAttacker = 0;

    private void Start()
    {
        SetLevelValues();
        EventHandler.StartGame();
    }
    private void SetLevelValues()
    {
        TryGetComponent(out Spawner spawner);
        if (spawner)
            spawner.SetSpawnerInfo(data.minSpawnDelayInSec, data.maxSpawnDelayInSec, data.activeLinesNumbers, data.enemiesToSpawn);
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
            EventHandler.WinGame();
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

    private void OnEnable()
    {
        EventHandler.OnAttackerDie += CountAttackerKilled;
        EventHandler.OnAttackerSpawned += CountAttackerSpawned;
    }

    private void OnDisable()
    {
        EventHandler.OnAttackerDie -= CountAttackerKilled;
        EventHandler.OnAttackerSpawned -= CountAttackerSpawned;
    }
    
}
