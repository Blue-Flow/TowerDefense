using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool isSpawning = true;

    private List<AttackerSpawner> activeSpawnPoints;
    private List<Attacker> attackerPrefabs;

    private int lastSpawnedLineNumber;
    private int lineToSpawn;

    private float minSpawnDelay = 1f;
    private float maxSpawnDelay = 2.5f;

    public void SetSpawnerInfo(float minDelay, float maxDelay, List<AttackerSpawner> attackerSpawnPoints, List<Attacker> attackerList)
    {
        minSpawnDelay = minDelay;
        maxSpawnDelay = maxDelay;

        activeSpawnPoints = attackerSpawnPoints;
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
    private IEnumerator SpawnEnnemies()
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
        ennemyToSpawn.transform.position = activeSpawnPoints[lineToSpawn].transform.position;
    }
    int GenerateRandomLineToSpawn()
    {
        while (lastSpawnedLineNumber == lineToSpawn)
        {
           lineToSpawn = Random.Range(0, activeSpawnPoints.Count);
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
    #region events
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
    #endregion
}
