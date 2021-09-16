using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private DefenderDataSO data;

    public DefenderDataSO GiveBaseInfo()
    {
        return data;
    }
    private void OnDestroy()
    {
        EventHandler.DefenderDie();
    }
}


