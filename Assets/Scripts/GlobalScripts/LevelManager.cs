using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int spawnPointsForThisLevel = 20;
    private int currentProgression;

    private void UpdateCurrentLevelProgression()
    {
        // Calcul de la valeur de progression actuelle en %
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
