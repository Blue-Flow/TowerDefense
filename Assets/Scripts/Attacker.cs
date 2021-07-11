using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float moveSpeed = 0f;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }

    public void SetMouvementSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
