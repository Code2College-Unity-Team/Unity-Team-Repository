using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class ScreenMan : MonoBehaviour
{

    
    
    public static bool isGameOver;
    public static bool isWinning;


    public GameObject gameOverScreen;

    public GameObject ContinueScreen;

    private void Awake()
    {
        isGameOver = false;
        isWinning = false;

        gameOverScreen.SetActive(false);
        ContinueScreen.SetActive(false);
    }

    void Update()
    {
        if(isGameOver)
        {
           gameOverScreen.SetActive(true); 
           
        }
        if(isWinning)
        {
            ContinueScreen.SetActive(true);
            Disable.Patrolling = true;
            
        }
        if(isGameOver == false)
        {
            gameOverScreen.SetActive(false);
        }


    }
}

