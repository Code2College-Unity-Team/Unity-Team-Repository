using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventie : MonoBehaviour
{
    public static bool isRunning;
    public static bool isQuestioning;


    public GameObject Level;

    public GameObject RiddlersDomain;

    private void Awake()
    {
        isRunning = true;
        isQuestioning = false;

        Level.SetActive(false);
        RiddlersDomain.SetActive(false);

    }

    void Update()
    {
        if(isRunning)
        {
           Level.SetActive(true);
           RiddlersDomain.SetActive(false); 
        }
        if(isQuestioning)
        {
            Level.SetActive(false);
            RiddlersDomain.SetActive(true);
        }


    }
}
