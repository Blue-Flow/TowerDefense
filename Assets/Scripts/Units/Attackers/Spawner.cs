using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool isSpawning = true;

    private List<Attacker> attackerPrefabs;

    private Vector2[] spawnPositions = 
        {
     new Vector2(10, 1.35f),
     new Vector2(10, 2.35f),
     new Vector2(10, 3.35f),
     new Vector2(10, 4.35f),
     new Vector2(10, 5.35f)
        };
    private int lastSpawnedLineNumber;
    private int lineToSpawn;

    private float minSpawnDelay = 1f;
    private float maxSpawnDelay = 2.5f;

    private int minNumberOfLines = 1;
    private int maxNumberOfLines = 5;

    public void SetSpawnerInfo(float minDelay, float maxDelay, int[] activeLines, List<Attacker> attackerList)
    {
        minSpawnDelay = minDelay;
        maxSpawnDelay = maxDelay;

        minNumberOfLines = activeLines[0];
        int activeLinesCount = activeLines.Length;
        maxNumberOfLines = activeLines[activeLinesCount-1];
        Debug.Log(maxNumberOfLines);

        attackerPrefabs = attackerList;
    }
    private void StartSpawning()
    {
        StartCoroutine(SpawnEnnemies());
    }
    private void StopSpawning()
    {
        isSpawning = false;
    }
    private IEnumerator SpawnEnnemies ()
    {
        while (isSpawning)
        {
            float timeToWait = GenerateRandomTimeToWait(minSpawnDelay, maxSpawnDelay);

            yield return new WaitForSeconds(timeToWait);
            
            SpawnAttacker();
            EventHandler.AttackerSpawned();
        }
    }
    private void SpawnAttacker()
    {
        lineToSpawn = GenerateRandomLineToSpawn();
        lastSpawnedLineNumber = lineToSpawn;
        int indexOfAttackerToSpawn = GenerateRandomAttackerToSpawn();
        Attacker ennemyToSpawn = Instantiate(attackerPrefabs[indexOfAttackerToSpawn], transform);
        ennemyToSpawn.transform.position = spawnPositions[lineToSpawn];
    }
    int GenerateRandomLineToSpawn()
    {
        while (lastSpawnedLineNumber == lineToSpawn)
        {
           lineToSpawn = Random.Range((minNumberOfLines - 1), (maxNumberOfLines - 1));
        }
        return lineToSpawn;
    }
    float GenerateRandomTimeToWait(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }
    int GenerateRandomAttackerToSpawn()
    {
        return Random.Range(0, attackerPrefabs.Count);
    }
    private void OnEnable()
    {
        EventHandler.OnStartGame += StartSpawning;
        EventHandler.OnSpawnCapReached += StopSpawning;
    }
    private void OnDisable()
    {
        EventHandler.OnStartGame -= StartSpawning;
        EventHandler.OnSpawnCapReached -= StopSpawning;
    }
}
