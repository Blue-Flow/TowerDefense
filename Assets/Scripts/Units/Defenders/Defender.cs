using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] public DefenderDataSO data;

    private void Start()
    {
        SetBaseHealth();
        SetBaseDamage();
    }
    private void SetBaseHealth()
    {
        TryGetComponent(out Health health);
        if (health)
            health.SetHealthPoints(data.health);
    }
    private void SetBaseDamage()
    {
        TryGetComponent(out Shooter shooter);
        if (shooter)
            shooter.SetDamage(data.damage);
    }
    private void OnDestroy()
    {
        EventHandler.DefenderDie();
    }
}


