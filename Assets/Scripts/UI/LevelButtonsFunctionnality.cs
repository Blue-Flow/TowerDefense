using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsFunctionnality : MonoBehaviour
{
    [SerializeField] private List<Button> levelButtonsListInOrder;

    private void Start()
    {
        List<bool> levelCompletionList = MainManager.Instance.GetLevelCompletion();

        for (int index = 0; index<levelButtonsListInOrder.Count; index ++)
        {
            if (levelCompletionList[index] == true)
            {
                levelButtonsListInOrder[index + 1].GetComponent<Image>().color = new Color(1,1,1, 0.0784f);
                levelButtonsListInOrder[index + 1].interactable = true;
            }
                
        }
    }
}
