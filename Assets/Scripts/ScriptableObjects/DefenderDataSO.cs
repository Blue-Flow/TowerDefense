using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDefenderData", menuName = "Unit/Defender")]
public class DefenderDataSO : ScriptableObject
{
    public GameObject defenderPrefab;
    public float moveSpeed;
    public int damage;
    public int health;
    public float attackRange;
    public int spawnCost;
    public LayerMask targetLayerMask;
    public Sprite defenderBaseSprite;
}
