using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private EnemyDataSO data;

    public EnemyDataSO GiveBaseInfo()
    {
        return data;
    }

    private void OnDestroy()
    {
        EventHandler.ResourceProduced(data.serenityAmountToGive);
        EventHandler.AttackerDie();
    }
}
