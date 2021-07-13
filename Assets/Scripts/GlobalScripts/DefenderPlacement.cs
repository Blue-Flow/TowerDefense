using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPlacement : MonoBehaviour
{
    [SerializeField] List<Defender> defendersPrefabs;
    private void OnMouseDown()
    {
        SpawnDefender(GetSelectedTilePosition());
    }
    private void SpawnDefender(Vector2 tileClickedPosition)
    {
        Instantiate(defendersPrefabs[0], tileClickedPosition, Quaternion.identity);
    }
    private Vector2 GetSelectedTilePosition()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        return worldPosition;
    }
}
