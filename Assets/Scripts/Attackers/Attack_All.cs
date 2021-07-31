using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_All : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().StartAttacking(otherObject);
        }
    }
}
