using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class RedCollisons : MonoBehaviour
{
    public Hatin hatin;

    private Rigidbody rb;
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI countText; 
    public int goal;
    public static bool isChecked;

    public static int timesTriggered;


    void Start()
    {
        Hatin.count = 0;
        SetCountText();
        timesTriggered = 0;
        isChecked = false;
        rb = GetComponent<Rigidbody>();


    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Token")) 
        {
            other.gameObject.SetActive(false);

            AddPoint();
             
        }
        if (other.gameObject.CompareTag("Riddler"))    /// For running into Rhodes
        {

            if(timesTriggered >= 1)    
            {
                AddPoint();
                timesTriggered = 0;
                other.gameObject.SetActive(false);
            }
            else
            {
                timesTriggered = timesTriggered + 1;
                nameText.text = "A Riddler";
                Transition();
            }
            
       
        }
        if (other.gameObject.CompareTag("Judge"))      /// For running into Jacque
        {
            

            ScreenMan.isGameOver = true; 
        }
        if(other.gameObject.CompareTag("Respawn"))  /// For CheckPoints
        {
           other.gameObject.SetActive(false);
           

           hatin.SavePlayer();

           isChecked = true;
        }

    }

    public void SetCountText()
    {
        countText.text = "Count:    " + Hatin.count.ToString() + "/"+ goal.ToString();
        nameText.text = "I CANT BELIEVE THIS";
        if(Hatin.count >= goal)
        {
           ScreenMan.isWinning = true;

        }
    }

    public void AddPoint()
    {
	    Debug.Log(Hatin.count);
        SetCountText(); 
        Hatin.count = Hatin.count + 1;
    }

    public void Transition()
    {
        Eventie.isRunning = false;
        Eventie.isQuestioning = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    

    
}

