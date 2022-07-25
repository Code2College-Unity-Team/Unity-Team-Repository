using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool inRange;
    bool interacting = false;

    private Animator _animator;

    private void OnEnable() {
        PlayerController.interact += OnInteracted;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (!_animator) {
            Debug.LogError("'_animator' is NULL you fucking moron! Create the damn object before you use it!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            inRange = true;
            Debug.Log("Player is in range");
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (interacting) {
                _animator.ResetTrigger("Interact");
                _animator.SetTrigger("Close");
                interacting = false;
            }
            inRange = false;
            Debug.Log("Player is no longer in range");
        }
    }

    void OnInteracted() {
        if (inRange) {
            Debug.Log("Player interacted");
            interacting = true;
            _animator.ResetTrigger("Close");
            _animator.SetTrigger("Interact");
        }
    }
}
