using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileDataSO data;
    private int damageToInflict;
    private Vector2 directionToMove;
    private string target;

    public void SetProjectileInfo(int value, Vector2 direction, string target)
    {
        damageToInflict = value;
        directionToMove = direction;
        this.target = target;
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
        if (collision.gameObject.CompareTag(target))
        {
            health.DealDamage(damageToInflict);
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
