using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee_All : MonoBehaviour
{
    private GameObject currentTarget;
    private Animator animator;
    private int damage;
    //private float attackRange = 1;
    //private LayerMask layerMask;
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
            damage = data.damage;
            //layerMask = 7;
        }
        else
        {
            TryGetComponent<Attacker>(out Attacker baseComponent_Attacker);
            if (baseComponent_Attacker)
            {
                EnemyDataSO data = baseComponent_Attacker.GiveBaseInfo();
                damage = data.damage;
                //layerMask = 8;
            }
            else Debug.Log("Attacker or Defender component missing");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            StartAttacking(otherObject);
        }
    }
    public void StartAttacking(GameObject target)
    {
        currentTarget = target;
        animator.SetBool("isAttacking", true);
    }
    private void Update()
    {
        //CheckForEnemyInRange();
        if (!currentTarget) StopAttacking();
    }
    /*private void CheckForEnemyInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, attackRange, layerMask);
        if (hit.collider == null && currentTarget)
            StopAttacking();
    }*/
    private void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
        currentTarget = null;
    }
    public void StrikeCurrentTarget()
    {
        if (!currentTarget)
            return;
        else currentTarget.GetComponent<Health>().DealDamage(damage);
    }
}
