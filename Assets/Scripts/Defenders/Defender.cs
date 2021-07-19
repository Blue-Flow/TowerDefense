using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int defenderCost;
    [SerializeField] float defenserRange;
    private bool isAttacking = false;
    LayerMask enemyLayerMask;
    private void Start()
    {
        enemyLayerMask = LayerMask.GetMask("Attackers");
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
        isAttacking = true;
        Debug.Log("is attacking :" + isAttacking);
    }
    private void StopAttacking()
    {
        isAttacking = false;
        Debug.Log("is attacking :" + isAttacking);
    }
}

