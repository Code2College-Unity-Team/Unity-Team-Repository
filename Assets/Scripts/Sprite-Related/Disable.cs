using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public static bool Patrolling;

    // Start is called before the first frame update
    void Start()
    {
        Patrolling = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        PatrolStop();
    }

    private void PatrolStop()
    {
        if(Patrolling)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Patrol>().enabled = false;
        }
    }
}
