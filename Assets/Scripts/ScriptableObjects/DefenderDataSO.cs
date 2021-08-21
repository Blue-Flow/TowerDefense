using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDefenderData", menuName = "Units/Defender Data")]
public class DefenderDataSO : ScriptableObject
{
    public string defenderName;
    public float moveSpeed;
    public int damage;
    public int health;
    public float attackRange;
    public int spawnCost;
    public LayerMask targetLayerMask;
}
