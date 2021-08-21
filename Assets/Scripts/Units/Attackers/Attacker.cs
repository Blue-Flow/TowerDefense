using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private GameObject currentTarget;
    private Animator animator;
    private float moveSpeed;
    [SerializeField] private EnemyDataSO data;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetBaseHealth();
        SetBaseMouvementSpeed();
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
    void Update()
    {
        Move();
        if (!currentTarget)  StopAttacking();
    }
    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }

    #region Animation called functions
    public void SetMouvementSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void SetBaseMouvementSpeed()
    {
        moveSpeed = data.moveSpeed;
    }
    public void TriggerJump()
    {
        animator.SetTrigger("jumpTrigger");
    }
    public void StartAttacking(GameObject target)
    {
        currentTarget = target;
        animator.SetBool("isAttacking", true);
    }
    public void StrikeCurrentTarget()
    {
        if (!currentTarget) 
            return;
        else currentTarget.GetComponent<Health>().DealDamage(data.damage);
    }
    #endregion
    private void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
        currentTarget = null;
    }
    private void OnDestroy()
    {
        EventHandler.AttackerDie();
    }
}
