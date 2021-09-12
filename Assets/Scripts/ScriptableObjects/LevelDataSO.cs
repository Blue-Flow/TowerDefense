using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level")]
public class LevelDataSO : ScriptableObject
{
    public int levelID;
    public int numberOfLives;
    public List<AttackerSpawner> activeSpawnPoints;

    [Header("Player")]
    public List<Defender> defendersToSpawn;
    public List<DefenderDataSO> defenderList;
    public int startingSerenityAmount;

    [Header("Enemies")]
    public int numberOfEnemies;
    public List<Attacker> enemiesToSpawn;
    public float minSpawnDelayInSec;
    public float maxSpawnDelayInSec;
    
}
