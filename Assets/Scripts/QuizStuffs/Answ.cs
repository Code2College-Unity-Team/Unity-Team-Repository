using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answ : MonoBehaviour
{

    public bool isCorrect = false;

    public QuizManager quizManager;
    

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("You're Right");
            quizManager.correct();
       }

        else
        {
            Debug.Log("You're wRONG");
            quizManager.wrong();
            

        }


    }
}
