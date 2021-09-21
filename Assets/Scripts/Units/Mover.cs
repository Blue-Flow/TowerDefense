using System.Collections;
using UnityEngine;


public class Mover : MonoBehaviour
{
    private float moveSpeed;
    private float baseMoveSpeed;
    private Animator animator;
    private Vector2 direction;

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
            baseMoveSpeed = data.moveSpeed;
            moveSpeed = baseMoveSpeed;
            direction = Vector2.right;
        }
        else
        {
            TryGetComponent<Attacker>(out Attacker baseComponent_Attacker);
            if (baseComponent_Attacker)
            {
                EnemyDataSO data = baseComponent_Attacker.GiveBaseInfo();
                baseMoveSpeed = data.moveSpeed;
                moveSpeed = baseMoveSpeed;
                direction = Vector2.left;
            }
            else Debug.Log("Attacker or Defender component missing");
        }
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    #region Animation called functions
    public void SetMouvementSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void SetBaseMouvementSpeed()
    {
        moveSpeed = baseMoveSpeed;
    }
    /*public void TriggerJump()
    {
        animator.SetTrigger("jumpTrigger");
    }*/
    #endregion
}