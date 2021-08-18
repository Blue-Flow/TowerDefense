using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip attackerDeathSFX;
    [SerializeField] AudioClip defenderDeathSFX;
    [SerializeField] AudioClip winSFX;
    private AudioSource audioSource;

    void Awake()
    {
        EventsSubscribe();
        audioSource = GetComponent<AudioSource>();
    }
    private void PlayAttackerDeathSFX()
    {
        // Actuellement le
        audioSource.PlayOneShot(attackerDeathSFX);
    }
    private void PlayDefenderDeathSFX()
    {
        audioSource.PlayOneShot(defenderDeathSFX);
    }
    private void PlayWinSFX()
    {
        audioSource.PlayOneShot(winSFX);
    }

    private void EventsSubscribe()
    {
        EventHandler.OnAttackerDie += PlayAttackerDeathSFX;
        EventHandler.OnDefenderDie += PlayDefenderDeathSFX;
        EventHandler.OnWinGame += PlayWinSFX;
    }

    private void OnDestroy()
    {
        EventHandler.OnAttackerDie -= PlayAttackerDeathSFX;
        EventHandler.OnDefenderDie -= PlayDefenderDeathSFX;
        EventHandler.OnWinGame -= PlayWinSFX;
    }
}
