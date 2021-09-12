using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPlacement : MonoBehaviour
{
    private bool isSpawning = false;
    private DefenderDataSO currentDefenderToSpawn;
    private void ActivateSpawnMode(DefenderDataSO defenderToSpawn)
    {
        currentDefenderToSpawn = defenderToSpawn;
        isSpawning = true;
    }
    private void DeactivateSpawnMode()
    {
        isSpawning = false;
        currentDefenderToSpawn = null;
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
        Instantiate(currentDefenderToSpawn.defenderPrefab, finalPosition, Quaternion.identity);
        DeactivateSpawnMode();
    }
    #region events
    private void OnEnable()
    {
        EventHandler.OnSpawnDefender += ActivateSpawnMode;
    }
    private void OnDisable()
    {
        EventHandler.OnSpawnDefender -= ActivateSpawnMode;
    }
    #endregion
}
