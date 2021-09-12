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

        int index = 0;
        foreach(bool level in levelCompletionList)
        {
            // Appel des boutons suivants pour les activer, attention, le premier bouton est dans la liste et n'est pas appelé
            if (level == true && index+1 < levelButtonsListInOrder.Count)
            {
                levelButtonsListInOrder[index + 1].GetComponent<Image>().color = new Color(1, 1, 1, 0.0784f);
                levelButtonsListInOrder[index + 1].interactable = true;
            }
            index++;
        }
    }
}
