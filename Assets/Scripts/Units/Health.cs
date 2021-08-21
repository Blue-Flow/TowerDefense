using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    private int healthPoints;

    public void SetHealthPoints(int value)
    {
        healthPoints = value;
    }
    public void DealDamage(int damageToInflict)
    {
        healthPoints -= damageToInflict;
        if (healthPoints < 1)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
    private void TriggerDeathVFX()
    {
        // death SFX géré ailleurs, retirer la partie VFX aussi ?
        if (!deathVFX) return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}
