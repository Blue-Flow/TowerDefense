using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static event Action<LevelDataSO> OnStartStoryMode;

    public static event Action OnStartGame;
    public static event Action OnLooseGame;
    public static event Action<int> OnWinGame;

    public static event Action OnAttackerDie;
    public static event Action OnDefenderDie;
    public static event Action<DefenderDataSO> OnStartSpawnDefender;
    public static event Action<DefenderDataSO> OnDefenderSpawned;
    public static event Action<int> OnResourceValueChange;
    public static event Action<float> OnLevelProgressionValueChange;
    public static event Action<int> OnResourceProduced;
    public static event Action OnAttackerSpawned;
    public static event Action OnLostLife;
    public static event Action OnSpawnCapReached;

    public static event Action OnSelectionCanceled;

    public static void StartStoryMode(LevelDataSO levelDataToLoad)
    {
        if (OnStartStoryMode != null)
        {
            OnStartStoryMode(levelDataToLoad);
        }
        else Debug.Log("Error with event OnStartStoryMode, no subscriber");
    }
    public static void StartGame()
    {
        if (OnStartGame != null)
        {
            OnStartGame();
        }
        else Debug.Log("Error with event OnStartGame, no subscriber");
    }
    public static void LooseGame()
    {
        if (OnLooseGame != null)
        {
            OnLooseGame();
        }
        else Debug.Log("Error with event OnLooseGame, no subscriber");
    }
    public static void WinGame(int levelNumber)
    {
        if (OnWinGame != null)
        {
            OnWinGame(levelNumber);
        }
        else Debug.Log("Error with event OnWinGame, no subscriber");
    }
    public static void AttackerDie()
    {
        if (OnAttackerDie != null)
        {
            OnAttackerDie();
        }
        else Debug.Log("Error with event OnAttackerDie, no subscriber");
    }
    public static void DefenderDie()
    {
        if (OnDefenderDie != null)
        {
            OnDefenderDie();
        }
        else Debug.Log("Error with event OnDefenderDie, no subscriber");
    }
    public static void DefenderSpawned(DefenderDataSO defender)
    {
        if (OnDefenderSpawned != null)
        {
            OnDefenderSpawned(defender);
        }
        else Debug.Log("Error with event OnDefenderSpawned, no subscriber");
    }
    public static void StartSpawnDefender(DefenderDataSO defender)
    {
        if (OnStartSpawnDefender != null)
        {
            OnStartSpawnDefender(defender);
        }
        else Debug.Log("Error with event OnStartSpawnDefender, no subscriber");
    }
    public static void LevelProgressionValueChange(float valueToDisplay)
    {
        if (OnLevelProgressionValueChange != null)
        {
            OnLevelProgressionValueChange(valueToDisplay);
        }
        else Debug.Log("Error with event OnLevelProgressionValueChange, no subscriber");
    }
    public static void ResourceValueChanged(int valueToDisplay)
    {
        if (OnResourceValueChange != null)
        {
            OnResourceValueChange(valueToDisplay);
        }
        else Debug.Log("Error with event OnResourceValueChange, no subscriber");
    }
    public static void ResourceProduced(int valueToAdd)
    {
        if (OnResourceProduced != null)
        {
            OnResourceProduced(valueToAdd);
        }
        else Debug.Log("Error with event OnResourceProduced, no subscriber");
    }
    public static void AttackerSpawned()
    {
        if (OnAttackerSpawned != null)
        {
            OnAttackerSpawned();
        }
        else Debug.Log("Error with event OnAttackerSpawned, no subscriber");
    }
    public static void LostLife()
    {
        if (OnLostLife != null)
        {
            OnLostLife();
        }
        else Debug.Log("Error with event OnLostLife, no subscriber");
    }
    public static void SpawnCapReached()
    {
        if (OnSpawnCapReached != null)
        {
            OnSpawnCapReached();
        }
        else Debug.Log("Error with event OnSpawnCapReached, no subscriber");
    }
    public static void SelectionCanceled()
    {
        if (OnSelectionCanceled != null)
        {
            OnSelectionCanceled();
        }
        else Debug.Log("Error with eventOnSelectionCanceled, no subscriber");
    }
}
    
