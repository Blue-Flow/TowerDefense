using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject thisCharacterGun;
    [Header("Projectile Info")]
    [SerializeField] Projectile projectile;
    private int damage;
    
    public void SetDamage(int value)
    {
        damage = value;
    }
    public void Shoot ()
    {
        Projectile projectileToShoot = Instantiate(projectile, thisCharacterGun.transform.position, Quaternion.identity);
        projectileToShoot.SetDamage(damage);
    }
}
