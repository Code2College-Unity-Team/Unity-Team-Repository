using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public delegate void OnInteracted();
    public static event OnInteracted interact;

    public float speed = 0;
    public float jumpHeight = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    [SerializeField]
    private GameObject camRotation;

    [SerializeField]
    public Vector3 respawn = new Vector3(0.0f, 0.5f, 0.0f);

    public GameObject Earth_Amulet;
    

    private int count;
    private Rigidbody rb;
    private Vector3 jump;
    private float movementX;
    private float movementY;
    private float lookX;
    private float lookY;
    private bool inRange;
    private bool canTakeAmulet;
    private bool stopped = false;
    private bool hasEarthAmulet = false;

    private Vector3 angleVelocity;
    private Quaternion deltaRotation;
    private Vector2 inputDirection;

    private bool canJump = false;

    // Start is called before the first frame update
    void Start() {
        count = 0;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
        SetCountText();

        winTextObject.SetActive(false);

        angleVelocity = new Vector3(0, 100, 0);
        deltaRotation = Quaternion.Euler(angleVelocity * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() { // Physical update
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        //if (movementY > 25) {
        //    rb.MoveRotation(deltaRotation);
        //}
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        inputDirection = movementVector.normalized;
        
    }

    void OnJump(InputValue jumpValue) {
            if (canJump) {
                canJump = false;
                rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
        }
    }

    /*void OnLook(InputValue deltaMouse) {
        Vector2 look = deltaMouse.Get<Vector2>();

        lookX = look.x;
        lookY = look.y;
    }*/

    // Collectible pickup

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Void")) {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            rb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            rb.isKinematic = true;
            transform.position = respawn;
            rb.isKinematic = false;
            //rb.MoveRotation(Quaternion.Euler(new Vector3(0.0f, 100.0f, 0.0f) * Time.fixedDeltaTime));
        }

        /*if (other.gameObject.CompareTag("Boss 1 Cutscene Gate")) {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            rb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            rb.isKinematic = true;
            transform.position = new Vector3(-142.61f, 16.28f, 6.09f);
            rb.isKinematic = false;
        }*/

        if (other.gameObject.CompareTag("Respawn")) {
            inRange = true;
            Debug.Log("Player can save");
        }

        if (other.gameObject.CompareTag("Stopper")) {
            if (!stopped) {
                rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                rb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
                rb.isKinematic = true;
                transform.position = new Vector3(-126.5f, 16.15f, 28.5f);
                rb.isKinematic = false;
                stopped = true;
            }
        }

        if (other.gameObject.CompareTag("Earth Amulet")) {
            canTakeAmulet = true;
            Debug.Log("Player can take the Earth Amulet");
        }


    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Respawn")) {
            inRange = false;
            Debug.Log("Player can no longer save");
        }

        if (other.gameObject.CompareTag("Earth Amulet")) {
            canTakeAmulet = false;
            Debug.Log("Player can no longer take the Earth Amulet");
        }
    }

    // Collisions...

    private void OnCollisionStay(Collision collision) {
        canJump = true;
    }

    private void OnCollisionExit(Collision collision) {
        canJump = false;
    }

    // Interact...

    void OnInteract() {
        interact?.Invoke();
        if (inRange) {
            Debug.Log("Player saved");
            respawn = transform.position;
        }

        if (canTakeAmulet) {
            Debug.Log("Player took the Earth Amulet");
            hasEarthAmulet = true;
            Earth_Amulet.gameObject.SetActive(false);
        }
    }

    void OnShield() {
        
    }

    // Text..

    void SetCountText() {
        countText.text = "Count: " + count.ToString();

        if (count >= 7) {
            winTextObject.SetActive(true);
        }
    }
}


