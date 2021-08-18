using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] List<Image> livesList;
    int index = 0;

    private void Awake()
    {
        EventsSubscribe();
    }
    private void DisplayLostLife()
    {
        livesList[index].gameObject.SetActive(false);
        if (index <= livesList.Count)
        index++;
    }
    private void EventsSubscribe()
    {
        EventHandler.OnLostLife += DisplayLostLife;
    }
    private void OnDestroy()
    {
        EventHandler.OnLostLife -= DisplayLostLife;
    }
}
