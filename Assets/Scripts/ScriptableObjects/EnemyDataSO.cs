using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Unit/Enemy")]
public class EnemyDataSO : ScriptableObject
{
    public string enemyName;
    public float moveSpeed;
    public int damage;
    public int health;
    public float attackRange;
    public int spawnCost;
    public int serenityAmountToGive;
    public LayerMask targetLayerMask;

}
