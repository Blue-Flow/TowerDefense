using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] int currentResourceAmount = 1000;

    private void Awake()
    {
        EventsSubscribe();
    }
    private void Start()
    {
        EventHandler.ResourceValueChanged(currentResourceAmount);
    }
    public void CheckDefenderCost(Defender defender)
    {
        int defenderCost = defender.GetCost();
        if (defenderCost <= currentResourceAmount)
        {
            SubstractResourceToCount(defenderCost);
            EventHandler.SpawnDefender(defender);
        }
        else Debug.Log("Not enough ressources" + currentResourceAmount + "/" + defenderCost);
    }
    private void SubstractResourceToCount(int amountToSubstract)
    {
        currentResourceAmount -= amountToSubstract;
        EventHandler.ResourceValueChanged(currentResourceAmount);
    }
    private void AddResourceToCount(int amountToAdd)
    {
        currentResourceAmount += amountToAdd;
        EventHandler.ResourceValueChanged(currentResourceAmount);
    }
    #region Events
    private void EventsSubscribe()
    {
        EventHandler.OnResourceProduced += AddResourceToCount;
    }

    private void OnDestroy()
    {
        EventHandler.OnResourceProduced -= AddResourceToCount;
    }
    #endregion
}
