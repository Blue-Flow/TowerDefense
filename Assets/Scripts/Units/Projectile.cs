using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ProjectileDataSO data;
    private int damageToInflict;
    [SerializeField] bool isDefenderProjectile = true;

    private Vector2 moveRight = new Vector2(1, 0);
    private Vector2 moveLeft = new Vector2(-1, 0);
    private Vector2 directionToMove;

    // Get the direction in which to move, and set the move function
    private void Start()
    {
        if (data.direction == MovingDirection.Right)
            directionToMove = moveRight;
        else directionToMove = moveLeft;
    }
    public void SetDamage(int value)
    {
        damageToInflict = value;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(directionToMove * Time.deltaTime * data.moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // est-ce qu'on peut faire autrement qu'avec un getcomponent qui consomme ?
        // est-ce qu'un compareTag consomme moins qu'un getComponent ?
        var health = collision.GetComponent<Health>();
        if (isDefenderProjectile && collision.gameObject.CompareTag("Attacker"))
        {
            health.DealDamage(damageToInflict);
            Destroy(gameObject);
        }
    }
}
public enum MovingDirection
{
    Right,
    Left,
}
