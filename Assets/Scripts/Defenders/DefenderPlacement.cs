using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPlacement : MonoBehaviour
{
    [SerializeField] List<Defender> defendersPrefabs;
    private bool isSpawning = false;
    private Defender currentDefenderToSpawn;
    private int indexOfDefenderToSpawn;
    private void Start()
    {
        EventsSubscribe();
    }
    private void ActivateSpawnMode(Defender defenderToSpawn)
    {
        //currentDefenderToSpawn = defendersPrefabs.Find(x => x == defenderToSpawn);
        indexOfDefenderToSpawn = defendersPrefabs.FindIndex(x => x == defenderToSpawn);
        Debug.Log(indexOfDefenderToSpawn);
        isSpawning = true;
    }
    private void DeactivateSpawnMode()
    {
        currentDefenderToSpawn = null;
        isSpawning = false;
    }
    private void OnMouseDown()
    {
        if (isSpawning)
            SpawnDefender(GetSelectedTilePosition());
    }
    private Vector2 GetSelectedTilePosition()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Vector2 finalPosition)
    {
        // Find the right prefab to spawn inside the list according to the currentDefenderToSpawn
        Instantiate(defendersPrefabs[indexOfDefenderToSpawn], finalPosition, Quaternion.identity);
        DeactivateSpawnMode();
    }
    private void EventsSubscribe()
    {
        EventHandler.OnSpawnDefender += ActivateSpawnMode;
    }
    private void OnDestroy()
    {
        EventHandler.OnSpawnDefender -= ActivateSpawnMode;
    }
}
