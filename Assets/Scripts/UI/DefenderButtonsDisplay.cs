using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButtonsDisplay : MonoBehaviour
{
    [SerializeField] private DefenderSpawnButton spawnButtonPrefab;
    private List<DefenderSpawnButton> listOfSpawnButton = new List<DefenderSpawnButton>();
    public void SetDefenderButtons(List<DefenderDataSO> dataList)
    {
        foreach(DefenderDataSO data in dataList)
        {
            DefenderSpawnButton newButton = Instantiate(spawnButtonPrefab, transform);
            newButton.SetButtonData(data);
            listOfSpawnButton.Add(newButton);
        }
    }
    private void OnSelectDefender1()
    {
        listOfSpawnButton[0]?.SendSelectedDefender();
    }
    private void OnSelectDefender2()
    {
        listOfSpawnButton[1]?.SendSelectedDefender();
    }
    private void OnSelectDefender3()
    {
        listOfSpawnButton[2]?.SendSelectedDefender();
    }
    private void OnSelectDefender4()
    {
        listOfSpawnButton[3]?.SendSelectedDefender();
    }
}
