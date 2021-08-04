using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    #region Events
    private void EventsSubscribe()
    {
        EventHandler.OnResourceValueChange += DisplayResourceValue;
    }
    private void OnDestroy()
    {
        EventHandler.OnResourceValueChange -= DisplayResourceValue;
    }
    #endregion
}
