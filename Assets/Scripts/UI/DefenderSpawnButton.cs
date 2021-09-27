using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DefenderSpawnButton : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    private DefenderDataSO defenderData;
    private Sprite spriteToShow;
    private Image image;
    private int costToShow;

    private void OnMouseDown()
    {
        SendSelectedDefender();
    }
    public void SendSelectedDefender()
    {
        EventHandler.SelectionCanceled();
        EventHandler.TrySpawnDefender(defenderData);
        image.color = Color.white;
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
        image = GetComponent<Image>();
        spriteToShow = defenderData.defenderBaseSprite;
        image.sprite = spriteToShow;
    }

    private void ResetButtonColor()
    {
        image.color = baseColor;
    }
    #region events
    private void OnEnable()
    {
        EventHandler.OnSelectionCanceled += ResetButtonColor;
    }

    private void OnDisable()
    {
        EventHandler.OnSelectionCanceled -= ResetButtonColor;
    }
    #endregion
}
