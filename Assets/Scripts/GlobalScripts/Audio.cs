using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip attackerDeathVFX;
    [SerializeField] AudioClip defenderDeathVFX;
    private AudioSource audioSource;

    void Awake()
    {
        EventsSubscribe();
        audioSource = GetComponent<AudioSource>();
    }
    private void PlayAttackerDeathVFX()
    {
            audioSource.PlayOneShot(attackerDeathVFX);
    }
    private void PlayDefenderDeathVFX()
    {
        audioSource.PlayOneShot(defenderDeathVFX);
    }

    private void EventsSubscribe()
    {
        EventHandler.OnAttackerDie += PlayAttackerDeathVFX;
        EventHandler.OnDefenderDie += PlayDefenderDeathVFX;
    }

    private void OnDestroy()
    {
        EventHandler.OnAttackerDie -= PlayAttackerDeathVFX;
        EventHandler.OnDefenderDie -= PlayDefenderDeathVFX;
    }
}
