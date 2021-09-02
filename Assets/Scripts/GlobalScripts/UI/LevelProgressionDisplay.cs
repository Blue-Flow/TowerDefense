using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionDisplay : MonoBehaviour
{
    [SerializeField] Slider defenseGauge;
    [SerializeField] Canvas levelCompletedCanvas;
    [SerializeField] GameObject levelCompletedText;
    [SerializeField] GameObject levelLostText;

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
    private void DisplayLooseMessage()
    {
        levelCompletedCanvas.gameObject.SetActive(true);
        levelLostText.SetActive(true);
    }
    private void DisplayWinMessage()
    {
        levelCompletedCanvas.gameObject.SetActive(true);
        levelCompletedText.SetActive(true);
    }
    private void EventsSubscribe()
    {
        EventHandler.OnLevelProgressionValueChange += DefenseGaugeDisplay;
        EventHandler.OnWinGame += DisplayWinMessage;
        EventHandler.OnLooseGame += DisplayLooseMessage;
    }
    private void OnDestroy()
    {
        EventHandler.OnLevelProgressionValueChange -= DefenseGaugeDisplay;
        EventHandler.OnWinGame -= DisplayWinMessage;
        EventHandler.OnLooseGame -= DisplayLooseMessage;
    }
}
