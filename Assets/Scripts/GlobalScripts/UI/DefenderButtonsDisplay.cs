using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButtonsDisplay : MonoBehaviour
{
    [SerializeField] List<GameObject> ButtonList;
    private List<Defender> activeDefenderList;

    public void SetDefendersButtons(List<Defender> thisLevelDefenderList)
    {
        activeDefenderList = thisLevelDefenderList;

        /*foreach(Defender defender in activeDefenderList)
        {
            switch(defender)
            {
                case defender == Defenders.Joie :
                        Debug.Log("Joie");
                    break;
            }
        }*/
    }
}
