using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Units/Enemy Data")]
public class EnemyDataSO : ScriptableObject
{
    public string enemyName;
    public float moveSpeed;
    public int damage;
    public int health;
    public float attackRange;
    public int spawnCost;

    // possible d'ajouter le modèle d'ennemi (sprite etc) directement ici. Utile ?
}
