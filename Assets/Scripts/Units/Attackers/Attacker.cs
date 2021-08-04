using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float moveSpeed = 0f;
    private GameObject currentTarget;
    private Animator animator;
    [SerializeField] int damageToDeal;
    private void Start()
    {
        animator = GetComponent<Animator>();
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
    public void SetMouvementSpeed(float speed)
    {
        moveSpeed = speed;
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
    private void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
    }
    public void StrikeCurrentTarget()
    {
        if (!currentTarget) { return; }
        else currentTarget.GetComponent<Health>().DealDamage(damageToDeal);
    }
    private void OnDestroy()
    {
        EventHandler.AttackerDie();
    }
}
