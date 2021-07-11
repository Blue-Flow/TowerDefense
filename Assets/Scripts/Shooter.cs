using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject thisCharacterGun;
    [Header("Projectile Info")]
    [SerializeField] Projectile projectile;
    [SerializeField] float projectileSpeed;
    public void Shoot ()
    {
        Projectile projectileToShoot = Instantiate(projectile, thisCharacterGun.transform.position, Quaternion.identity);
    }
}
