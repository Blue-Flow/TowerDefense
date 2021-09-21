using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    private int healthPoints;

    private void Start()
    {
        GetInfo();
    }
    private void GetInfo()
    {
        TryGetComponent<Defender>(out Defender baseComponent);
        if (baseComponent)
        {
            DefenderDataSO data = baseComponent.GiveBaseInfo();
            healthPoints = data.health;
        }
        else
        {
            TryGetComponent<Attacker>(out Attacker baseComponent_Attacker);
            if (baseComponent_Attacker)
            {
                EnemyDataSO data = baseComponent_Attacker.GiveBaseInfo();
                healthPoints = data.health;
            }
            else Debug.Log("Attacker or Defender component missing");
        }
    }
    public void DealDamage(int damageToInflict)
    {
        healthPoints -= damageToInflict;
        if (healthPoints < 1)
        {
            Destroy(gameObject);
        }
    }
    /*private void TriggerDeathVFX()
    {
        // death SFX géré ailleurs, retirer la partie VFX aussi ?
        if (!deathVFX) return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }*/
}
