using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionDisplay : MonoBehaviour
{
    [SerializeField] Slider defenseGauge;
    [SerializeField] Canvas levelCompletedCanvas;
    private void Awake()
    {
        EventsSubscribe();
    }
    private void Start()
    {
        levelCompletedCanvas.gameObject.SetActive(false);
    }
    private void DefenseGaugeDisplay(float valueToDisplay)
    {
        defenseGauge.value = valueToDisplay;
    }
    private void DisplayWinMessage()
    {
        levelCompletedCanvas.gameObject.SetActive(true);
    }
    private void EventsSubscribe()
    {
        EventHandler.OnLevelProgressionValueChange += DefenseGaugeDisplay;
        EventHandler.OnWinGame += DisplayWinMessage;
    }
    private void OnDestroy()
    {
        EventHandler.OnLevelProgressionValueChange -= DefenseGaugeDisplay;
        EventHandler.OnWinGame -= DisplayWinMessage;
    }
}
