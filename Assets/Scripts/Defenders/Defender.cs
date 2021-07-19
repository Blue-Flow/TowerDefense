using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int defenderCost;
    [SerializeField] float defenserRange;
    private bool isAttacking = false;
    LayerMask enemyLayerMask;
    Animator animator;
    private void Start()
    {
        enemyLayerMask = LayerMask.GetMask("Attackers");
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckForEnemyInRange();
    }
    private void CheckForEnemyInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, defenserRange, enemyLayerMask);
        if (hit.collider != null && !isAttacking)
            StartAttacking();
        if (hit.collider == null && isAttacking)
            StopAttacking();
    }
    public int GetCost()
    {
        return defenderCost;
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

