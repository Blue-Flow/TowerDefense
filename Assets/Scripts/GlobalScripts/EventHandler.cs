using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static event Action OnStartGame;
    public static event Action<bool> OnUnitDie;

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
}
