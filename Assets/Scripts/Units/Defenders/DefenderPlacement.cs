using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPlacement : MonoBehaviour
{
    private List<Defender> defendersPrefabs;
    private bool isSpawning = false;
    private int indexOfDefenderToSpawn;
    private void Start()
    {
        EventsSubscribe();
    }
    public void SetDefendersToSpawn(List<Defender> defenderList)
    {
        defendersPrefabs = defenderList;
    }
    private void ActivateSpawnMode(Defender defenderToSpawn)
    {
        // Find the right prefab to spawn inside the list according to the currentDefenderToSpawn
        indexOfDefenderToSpawn = defendersPrefabs.FindIndex(x => x == defenderToSpawn);
        isSpawning = true;
    }
    private void DeactivateSpawnMode()
    {
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
