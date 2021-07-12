using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPlacement : MonoBehaviour
{
    [SerializeField] List<Defender> defendersPrefabs;
    private Vector2 tileClickedPosition;
    private void OnMouseDown()
    {
        tileClickedPosition = GetSelectedTile();
        if (tileClickedPosition != Vector2.zero)
            SpawnDefender();
    }
    private void SpawnDefender()
    {
        Instantiate(defendersPrefabs[0], tileClickedPosition, Quaternion.identity);
    }
    private Vector2 GetSelectedTile()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            return hit.collider.transform.position;
        }
        else return Vector2.zero;
    }
}
