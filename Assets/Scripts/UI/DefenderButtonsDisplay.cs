using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButtonsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject spawnButtonPrefab;
    public void SetDefenderButtons(List<DefenderDataSO> dataList)
    {
        foreach(DefenderDataSO data in dataList)
        {
            GameObject newButton = Instantiate(spawnButtonPrefab, transform);
            newButton.GetComponent<DefenderSpawnButton>().SetButtonData(data);
        }
    }
}
