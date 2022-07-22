using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Transform respawnPoint;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //add rigidbody
        count = 0; //set count to 0

        SetCountText();
        winTextObject.SetActive(false); //set win to not winning
    }

    private void Update()
    {
        if(transform.position.y < 0)
        {
            Respawn(); //if the player moves below respawn
        }
        if (Input.GetKeyDown ("space") && GetComponent<Rigidbody>().transform.position.y <= 0.5f) {
                rb.AddForce (new Vector3 (0f , 300f, 0f)); //if player hits space, apply 500 force up iff y value is <=0.5f
     }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 11)//edit depending on how many collectibles there are
        {
            winTextObject.SetActive(true);
        }

    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
        other.gameObject.SetActive(false);
        count = count+1;
        SetCountText();
        }
       
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Respawn(); //go to respawn
        }
        if(collision.gameObject.CompareTag("Checkpoint")){
            respawnPoint.position = transform.position;
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }
}