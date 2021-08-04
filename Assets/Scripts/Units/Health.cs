using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoints = 1;
    [SerializeField] GameObject deathVFX;

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
        // death SFX g�r� ailleurs, retirer la partie VFX aussi ?
        if (!deathVFX) return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}
