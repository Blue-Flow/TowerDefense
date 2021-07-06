using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static event Action OnStartGame;

    public static void StartGame()
    {
        if (OnStartGame != null)
        {
            OnStartGame();
        }
        else Debug.Log("Error with event OnStartGame, no subscriber");
    }
}
