using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DefenderSpawnButton : MonoBehaviour
{
    private DefenderDataSO defenderData;
    private Sprite spriteToShow;
    private int costToShow;
    private DefenderSpawner defenderSpawner;
    private void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }
    private void OnMouseDown()
    {
        defenderSpawner.CheckDefenderCost(defenderData);
    }
    public void SetButtonData(DefenderDataSO data)
    {
        defenderData = data;
        SetButtonImage();
        SetButtonCost();
    }

    private void SetButtonCost()
    {
        costToShow = defenderData.spawnCost;
        GetComponentInChildren<TextMeshProUGUI>().text = costToShow.ToString();
    }

    private void SetButtonImage()
    {
        spriteToShow = defenderData.defenderBaseSprite;
        GetComponent<Image>().sprite = spriteToShow;
    }
}
