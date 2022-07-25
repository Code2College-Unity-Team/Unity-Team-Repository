using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public bool inRange;
    public InputAction interactKey;
    public UnityEvent interactAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange) {
            if (interactKey.ReadValue<bool>()) {
                interactAction.Invoke();
                Debug.Log("Player interacted");
            }
        }
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            inRange = true;
            Debug.Log("Player is in range");
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            inRange = false;
            Debug.Log("Player is no longer in range");
        }
    }
}


