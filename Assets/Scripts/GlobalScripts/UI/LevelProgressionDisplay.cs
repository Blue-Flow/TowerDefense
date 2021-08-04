using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionDisplay : MonoBehaviour
{
    [SerializeField] Slider defenseGauge;
    private void Awake()
    {
        EventsSubscribe();
    }
    private void DefenseGaugeDisplay(float valueToDisplay)
    {
        defenseGauge.value = valueToDisplay;
    }
    private void EventsSubscribe()
    {
        EventHandler.OnLevelProgressionValueChange += DefenseGaugeDisplay;
    }
    private void OnDestroy()
    {
        EventHandler.OnLevelProgressionValueChange -= DefenseGaugeDisplay;
    }
}
