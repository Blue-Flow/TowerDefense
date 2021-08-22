using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level")]
public class LevelDataSO : ScriptableObject
{
    public int levelID;
    public int numberOfLives;
    public int[] activeLinesNumbers;

    [Header("Player")]
    public List<Defender> defendersToSpawn;

    [Header("Enemies")]
    public int numberOfEnemies;
    public List<Attacker> enemiesToSpawn;
    public float minSpawnDelayInSec;
    public float maxSpawnDelayInSec;
    
}
