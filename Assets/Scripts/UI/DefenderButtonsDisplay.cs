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

    /*public void SetDefendersButtons(List<Defender> thisLevelDefenderList)
    {
        activeDefenderList = thisLevelDefenderList;

        foreach(Defender defender in activeDefenderList)
        {
            if (defender.name == "Defender_Joie")
                Button_Joie.SetActive(true);
            if (defender.name == "Defender_Amusement")
                Button_Amusement.SetActive(true);
            if (defender.name == "Defender_S�r�nit�")
                Button_S�r�nit�.SetActive(true);
            if (defender.name == "Defender_R�silience")
                Button_R�silience.SetActive(true);
        }
    }
    */
}
