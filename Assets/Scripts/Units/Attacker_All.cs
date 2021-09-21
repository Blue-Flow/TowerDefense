using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker_All : MonoBehaviour
{
    private bool isAttacking = false;
    private LayerMask enemyLayerMask;
    private float attackRange;
    private Animator animator;
    private Vector2 attackDirection;
    private int damage;
    private string target;

    [SerializeField] private GameObject thisCharacterGun;
    [SerializeField] private Projectile projectile;
    private void Start()
    {
        animator = GetComponent<Animator>();
        GetInfo();
    }
    private void GetInfo()
    {
        TryGetComponent<Defender>(out Defender baseComponent);
        if (baseComponent)
        {
            DefenderDataSO data = baseComponent.GiveBaseInfo();
            enemyLayerMask = data.targetLayerMask;
            attackRange = data.attackRange;
            attackDirection = Vector2.right;
            damage = data.damage;
            target = "Attacker";

            ///!\ défenseurs ne peuvent pas tirer derrière eux
        }
        else
        {
            TryGetComponent<Attacker>(out Attacker baseComponent_Attacker);
            if (baseComponent_Attacker)
            {
                EnemyDataSO data = baseComponent_Attacker.GiveBaseInfo();
                enemyLayerMask = data.targetLayerMask;
                attackRange = data.attackRange;
                attackDirection = Vector2.left;
                damage = data.damage;
                target = "Defender";
            }
            else Debug.Log("Attacker or Defender component missing");
        }
    }
    private void Update()
    {
        CheckForEnemyInRange();
    }
    private void CheckForEnemyInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, attackRange, enemyLayerMask);
        if (hit.collider != null && !isAttacking)
            StartAttacking();
        if (hit.collider == null && isAttacking)
            StopAttacking();
    }
    private void StartAttacking()
    {
        animator.SetBool("isAttacking", true);
        isAttacking = true;
    }
    private void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
    }
    public void Shoot()
    {
        Projectile projectileToShoot = Instantiate(projectile, thisCharacterGun.transform.position, Quaternion.identity);
        projectileToShoot.SetProjectileInfo(damage, attackDirection, target);
    }
}
