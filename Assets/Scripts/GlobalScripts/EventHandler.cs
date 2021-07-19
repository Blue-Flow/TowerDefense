using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static event Action OnStartGame;
    public static event Action<bool> OnUnitDie;
    public static event Action<Defender> OnSpawnDefender;
    public static event Action<int> OnResourceValueChange;
    public static event Action<int> OnResourceProduced;
    //public static event Action<> OnAttackerSpawned;

    public static void StartGame()
    {
        if (OnStartGame != null)
        {
            OnStartGame();
        }
        else Debug.Log("Error with event OnStartGame, no subscriber");
    }
    public static void UnitDie(bool isAttacker)
    {
        if (OnUnitDie != null)
        {
            OnUnitDie(isAttacker);
        }
        else Debug.Log("Error with event OnUnitDie, no subscriber");
    }
    public static void SpawnDefender(Defender defender)
    {
        if (OnSpawnDefender != null)
        {
            OnSpawnDefender(defender);
        }
        else Debug.Log("Error with event OnSpawnDefender, no subscriber");
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
    /*public static void AttackerSpawned()
    {
        if (OnAttackerSpawned != null)
        {
            OnAttackerSpawned();
        }
        else Debug.Log("Error with event OnAttackerSpawned, no subscriber");
    }*/
}
