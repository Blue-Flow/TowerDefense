using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool isSpawning = true;

    [SerializeField] List<Attacker> attackerPrefabs = new List<Attacker>();
    private Vector2[] spawnPositions = 
        {
     new Vector2(10, 1.35f),
     new Vector2(10, 2.35f),
     new Vector2(10, 3.35f),
     new Vector2(10, 4.35f),
     new Vector2(10, 5.35f)
        };

    [Header("LevelInfo")] // Transfer this to the LevelManager and add a method to get the info from it at the start of the level
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 2.5f;

    [SerializeField] int minNumberOfLines = 1;
    [SerializeField] int maxNumberOfLines = 5;
    void Start()
    { 
        StartCoroutine(SpawnEnnemies());

    }
    IEnumerator SpawnEnnemies ()
    {
        while (isSpawning)
        {
            float timeToWait = GenerateRandomTimeToWait(minSpawnDelay, maxSpawnDelay);

            yield return new WaitForSeconds(timeToWait);

            SpawnAttacker();
        }
    }
    private void SpawnAttacker()
    {
        int lineToSpawn = GenerateRandomLineToSpawn();
        Attacker ennemyToSpawn = Instantiate(attackerPrefabs[0]);
        ennemyToSpawn.transform.position = spawnPositions[lineToSpawn];
    }
    int GenerateRandomLineToSpawn()
    {
        return Random.Range((minNumberOfLines-1), (maxNumberOfLines-1));
    }
    float GenerateRandomTimeToWait(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }
}
