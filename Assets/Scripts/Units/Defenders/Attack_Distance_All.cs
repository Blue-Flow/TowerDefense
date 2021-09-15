using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Distance_All : MonoBehaviour
{
    private bool isAttacking = false;
    private LayerMask enemyLayerMask;
    private float attackRange;
    Animator animator;
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
            enemyLayerMask = baseComponent.data.targetLayerMask;
            attackRange = baseComponent.data.attackRange;
        }
        else Debug.Log("Defender component missing");
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
