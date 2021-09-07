using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] GameObject lifeImage;
    private List<GameObject> livesList = new List<GameObject>();
    private int livesNumber;
    int index;

    public void SetLiveDisplaySettings(int numberOfLives)
    {
        livesNumber = numberOfLives;
        
        for (int index = 0; index < livesNumber; index++)
        {
            GameObject newLife = Instantiate(lifeImage, transform);
            livesList.Add(newLife);
        }
        index = 0;
    }

    private void DisplayLostLife()
    {
        livesList[index].GetComponent<SpriteRenderer>().color = Color.gray;
        if (index <= livesList.Count)
            index++;
    }
    #region events
    private void OnEnable()
    {
        EventHandler.OnLostLife += DisplayLostLife;
    }
    private void OnDisable()
    {
        EventHandler.OnLostLife -= DisplayLostLife;
    }
    #endregion
}
