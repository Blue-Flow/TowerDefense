using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Distance_All : MonoBehaviour
{
    private bool isAttacking = false;
    private LayerMask enemyLayerMask;
    private float attackRange;
    private Animator animator;
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
        }
        else
        {
            TryGetComponent<Attacker>(out Attacker baseComponent_Attacker);
            if (baseComponent_Attacker)
            {
                EnemyDataSO data = baseComponent_Attacker.GiveBaseInfo();
                enemyLayerMask = data.targetLayerMask;
                attackRange = data.attackRange;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, attackRange, enemyLayerMask);
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
}
