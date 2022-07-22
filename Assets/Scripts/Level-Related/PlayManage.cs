using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManage : MonoBehaviour
{
    public Hatin hatin;

    public RedCollisons redcollisons;



    public void StartNewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    public void LoadSave()
    {
        if(RedCollisons.isChecked)
        {
            hatin.LoadPlayer();
            ScreenMan.isGameOver = false;

            Debug.Log("YOu're Loading");
            redcollisons.AddPoint();
            
            for(int i = 0; i < ListOfTheDead.dead.Count; i++)
            {
                ListOfTheDead.dead[i].SetActive(true);
            }
            
        }
        else
        {
            ReplayLevel();
        }
        
    }
    
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You quit");
    }
}
