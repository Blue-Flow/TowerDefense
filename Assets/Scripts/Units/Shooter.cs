using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject thisCharacterGun;
    [SerializeField] private Projectile projectile;
    private int damage;
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
            damage = data.damage;
        }
        else
        {
            TryGetComponent<Attacker>(out Attacker baseComponent_Attacker);
            if (baseComponent_Attacker)
            {
                EnemyDataSO data = baseComponent_Attacker.GiveBaseInfo();
                damage = data.damage;
            }
            else Debug.Log("Attacker or Defender component missing");
        }
    }
    public void Shoot ()
    {
        Projectile projectileToShoot = Instantiate(projectile, thisCharacterGun.transform.position, Quaternion.identity);
        projectileToShoot.SetDamage(damage);
    }
}
