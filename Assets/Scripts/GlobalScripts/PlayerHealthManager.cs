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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SubstractHealth();
        CheckRemainingHealth();
    }
    private void SubstractHealth()
    {
        currentHealth--;
        EventHandler.LostLife();
    }
    private void CheckRemainingHealth()
    {
        if (currentHealth == 0)
            EventHandler.LooseGame();
    }
}
