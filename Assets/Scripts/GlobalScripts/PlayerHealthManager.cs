using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    private int currentHealth;
    public void SetHealth(int value)
    {
        currentHealth = value;
    }
    private void LooseLife()
    {
        SubstractHealth();
        CheckRemainingHealth();
    }
    private void SubstractHealth()
    {
        currentHealth--;
    }
    private void CheckRemainingHealth()
    {
        if (currentHealth <= 0)
            EventHandler.LooseGame();
    }
    private void OnEnable()
    {
        EventHandler.OnLostLife += LooseLife;
    }
    private void OnDestroy()
    {
        EventHandler.OnLostLife -= LooseLife;
    }
}
