using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // from https://gamedev.stackexchange.com/a/163322
    public TMP_Text self;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
        self.color = Color.gray;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        self.color = Color.white;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //SceneManager.LoadScene("Main");
        Application.Quit();
    }
}
