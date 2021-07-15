using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int defenderCost;

    public int GetCost()
    {
        return defenderCost;
    }
}
