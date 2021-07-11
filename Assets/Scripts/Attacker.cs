using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 10f)] [SerializeField] float moveSpeed = 1.0f;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }
}
