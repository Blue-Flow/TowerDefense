using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int spawnPointsForThisLevel = 20;
    private float currentProgression = 0;
    private int numberOfDeadAttacker = 0;
    private void Awake()
    {
        EventsSubscribe();
    }
    private void UpdateCurrentLevelProgression()
    {
        numberOfDeadAttacker++;
        currentProgression = ((float)(numberOfDeadAttacker) / (float)(spawnPointsForThisLevel));
        EventHandler.LevelProgressionValueChange(currentProgression);
    }

    private void EventsSubscribe()
    {
        EventHandler.OnAttackerDie += UpdateCurrentLevelProgression;
    }

    private void OnDestroy()
    {
        EventHandler.OnAttackerDie -= UpdateCurrentLevelProgression;
    }
}
