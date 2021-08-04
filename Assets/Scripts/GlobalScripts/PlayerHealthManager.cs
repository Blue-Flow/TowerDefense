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
    }
    private void CheckRemainingHealth()
    {
        if (currentHealth == 0)
           StartCoroutine(nameof(LoadEndScreen_Loose));
    }
    private IEnumerator LoadEndScreen_Loose()
    {
        Time.timeScale = 0.2f;
        // play SFX
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
}
