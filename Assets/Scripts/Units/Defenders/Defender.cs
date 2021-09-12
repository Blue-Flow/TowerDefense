using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private DefenderDataSO data;
    private bool isAttacking = false;
    LayerMask enemyLayerMask;
    Animator animator;
    private void Start()
    {
        enemyLayerMask = data.targetLayerMask;
        animator = GetComponent<Animator>();
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
    private void Update()
    {
        CheckForEnemyInRange();
    }
    private void CheckForEnemyInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, data.attackRange, enemyLayerMask);
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
    private void OnDestroy()
    {
        EventHandler.DefenderDie();
    }
}


