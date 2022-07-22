using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] moves;
    int currentMove;

    
    
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    private void Awake()
    {
        currentMove = 0;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = moves[currentMove].position;

        if(Vector3.Distance(transform.position, moves[currentMove].position) < 1)
        {
            IteratecurrentMove();
        }
    }
    
    void IteratecurrentMove()
    {
        currentMove= currentMove + 1;
        if(currentMove== moves.Length)
        {
            currentMove = 0;
        }
    }
}
