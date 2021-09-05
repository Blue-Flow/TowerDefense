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
    public void CheckDefenderCost(Defender defender)
    {
        int defenderCost = defender.GetCost();
        if (defenderCost <= serenityAmount)
        {
            SubstractResourceToCount(defenderCost);
            EventHandler.SpawnDefender(defender);
        }
        else Debug.Log("Not enough ressources" + serenityAmount + "/" + defenderCost);
    }
    private void SubstractResourceToCount(int amountToSubstract)
    {
        serenityAmount -= amountToSubstract;
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
    }

    private void OnDisable()
    {
        EventHandler.OnResourceProduced -= AddResourceToCount;
    }
    #endregion
}
