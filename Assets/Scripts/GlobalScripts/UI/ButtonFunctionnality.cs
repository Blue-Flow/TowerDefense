using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctionnality : MonoBehaviour
{
    public void TurnONOFFObject (GameObject ObjectToActOn)
    {
        ObjectToActOn.SetActive(!ObjectToActOn.activeSelf);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
