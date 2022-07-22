using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    

    public List<AndAnswers> QnA;
    public List<AndAnswers> AnQ;

    public GameObject[] options;
    public int currentQuestion;

    public int timesWrong; 

    public TextMeshProUGUI QuestionTxt;





    

    private void Start()
    {
        generateQuestion();

        timesWrong = 0;

    }    

    public void correct()
    {
        AnQ.Add(QnA[currentQuestion]);
        QnA.RemoveAt(currentQuestion);

        generateQuestion();

        Hatin.count = Hatin.count + 1;

        timesWrong = 0;

        Eventie.isRunning = true;
        Eventie.isQuestioning = false;
        
    }
    public void wrong()
    {
        QuestionTxt.text = QnA[currentQuestion].Question + "            TRY AGAIN";

        if(timesWrong == 1)
        {
            ScreenMan.isGameOver = true;
            timesWrong = 0;

        }
        else
        {
            timesWrong = timesWrong + 1;
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answ>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answ>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;

            SetAnswers();
        }
        else
        {
           QnA.AddRange(AnQ);
           AnQ.Clear();
        }
    }
}
