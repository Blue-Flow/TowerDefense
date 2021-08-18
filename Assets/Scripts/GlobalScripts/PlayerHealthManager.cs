using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int initialPlayerHealth = 3;
    private int currentHealth;
    private void Start()
    {
        currentHealth = initialPlayerHealth;
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
