using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender currentSelectedDefender;
    private int currentResourceAmount = 25;

    private void Start()
    {
        EventHandler.ResourceValueChanged(currentResourceAmount);
    }
    public void CheckDefenderCost(Defender defender)
    {
        int defenderCost = defender.GetCost();
        if (defenderCost <= currentResourceAmount)
        {
            currentSelectedDefender = defender;
            currentResourceAmount -= defenderCost;
            EventHandler.SpawnDefender(defender);
            EventHandler.ResourceValueChanged(currentResourceAmount);
        }
        else Debug.Log("Not enough ressources" + currentResourceAmount + "/" + defenderCost);
    }

}
