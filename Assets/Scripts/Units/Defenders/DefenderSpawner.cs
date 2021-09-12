using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private int serenityAmount;

    public void SetSerenityAmount(int value)
    {
        serenityAmount = value;
    }
    private void Start()
    {
        EventHandler.ResourceValueChanged(serenityAmount);
    }
    public void CheckDefenderCost(DefenderDataSO defenderData)
    {
        if (defenderData.spawnCost <= serenityAmount)
        {
            EventHandler.StartSpawnDefender(defenderData);
        }
        else Debug.Log("Not enough ressources" + serenityAmount + "/" + defenderData.spawnCost);
    }
    private void SubstractResourceToCount(DefenderDataSO defenderData)
    {
        serenityAmount -= defenderData.spawnCost;
        EventHandler.ResourceValueChanged(serenityAmount);
    }
    private void AddResourceToCount(int amountToAdd)
    {
        serenityAmount += amountToAdd;
        EventHandler.ResourceValueChanged(serenityAmount);
    }
    #region Events
    private void OnEnable()
    {
        EventHandler.OnResourceProduced += AddResourceToCount;
        EventHandler.OnDefenderSpawned += SubstractResourceToCount;
    }

    private void OnDisable()
    {
        EventHandler.OnResourceProduced -= AddResourceToCount;
        EventHandler.OnDefenderSpawned -= SubstractResourceToCount;
    }
    #endregion
}
