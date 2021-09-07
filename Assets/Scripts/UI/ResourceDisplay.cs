using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourcesDisplay;

    private void DisplayResourceValue(int valueToDisplay)
    {
        resourcesDisplay.text = valueToDisplay.ToString();
    }
    private void OnEnable()
    {
        EventHandler.OnResourceValueChange += DisplayResourceValue;
    }
    private void OnDisable()
    {
        EventHandler.OnResourceValueChange -= DisplayResourceValue;
    }
}

