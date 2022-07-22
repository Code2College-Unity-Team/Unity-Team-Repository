using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfTheDead : MonoBehaviour
{
    public static List<GameObject> dead = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Token")) 
        {
            dead.Add(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("Riddler"))    /// For running into Rhodes
        {
            
            if(RedCollisons.timesTriggered >= 1)    
            {
                dead.Add(other.gameObject);
            }
        }
        if(other.gameObject.CompareTag("Respawn"))  /// For CheckPoints
        {
            dead.Clear();
        }
    }
}
