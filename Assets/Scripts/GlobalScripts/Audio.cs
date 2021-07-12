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

    private void EventsSubscribe()
    {
        EventHandler.OnUnitDie += PlayUnitDeathVFX;
    }

    private void PlayUnitDeathVFX(bool isAttacker)
    {
        if (isAttacker)
        audioSource.PlayOneShot(attackerDeathVFX);
        else audioSource.PlayOneShot(defenderDeathVFX);
    }
    private void OnDestroy()
    {
        EventHandler.OnUnitDie -= PlayUnitDeathVFX;
    }
}
