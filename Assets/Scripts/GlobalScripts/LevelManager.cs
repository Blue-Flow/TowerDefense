using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int spawnNumberForThisLevel = 20;
    private int numberOfSpawnedAttacker = 0;
    private int numberOfDeadAttacker = 0;
    private void Awake()
    {
        EventsSubscribe();
    }
    private void UpdateCurrentLevelProgression()
    {
        float currentProgression = (float) numberOfDeadAttacker / (float) spawnNumberForThisLevel;
        EventHandler.LevelProgressionValueChange(currentProgression);
    }
    private void CountAttackerKilled()
    {
        numberOfDeadAttacker++;
        UpdateCurrentLevelProgression();
        if (numberOfDeadAttacker == numberOfSpawnedAttacker)
        {
            EventHandler.WinGame();
        }
    }
    private void CountAttackerSpawned()
    {
        numberOfSpawnedAttacker++;
        if (numberOfSpawnedAttacker >= spawnNumberForThisLevel)
        {
            Debug.Log("Cap reached");
            StopSpawner();
        }
    }
    private void StopSpawner()
    {
        FindObjectOfType<Spawner>().SetIsSpawning(false);
    }
    private void EventsSubscribe()
    {
        EventHandler.OnAttackerDie += CountAttackerKilled;
        EventHandler.OnAttackerSpawned += CountAttackerSpawned;
    }

    private void OnDestroy()
    {
        EventHandler.OnAttackerDie -= CountAttackerKilled;
        EventHandler.OnAttackerSpawned -= CountAttackerSpawned;
    }
    
}
