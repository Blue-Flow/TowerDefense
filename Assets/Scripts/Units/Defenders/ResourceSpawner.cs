using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] int amountOfResourceToSpawn = 2;

    public void SpawnResource()
    {
        EventHandler.ResourceProduced(amountOfResourceToSpawn);
    }
}
