using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourcesDisplay;

    private void Start()
    {
        EventsSubscribe();
    }
    private void DisplayResourceValue(int valueToDisplay)
    {
        resourcesDisplay.text = valueToDisplay.ToString();
    }
    private void EventsSubscribe()
    {
        EventHandler.OnResourceValueChange += DisplayResourceValue;
    }
    private void OnDestroy()
    {
        EventHandler.OnResourceValueChange -= DisplayResourceValue;
    }
}
