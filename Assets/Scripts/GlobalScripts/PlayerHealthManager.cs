using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    // Currently one life, death on enemy that goes through
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
