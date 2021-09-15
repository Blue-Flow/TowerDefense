using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // A class of attackers that jump over defenders that have the obstacle component
    // But also attack all the other defenders
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.GetComponent<Obstacle>())
            {
                GetComponent<Mover>().TriggerJump();
            }
            else 
            GetComponent<Attack_Melee_All>().StartAttacking(otherObject);
        }
    }
}
