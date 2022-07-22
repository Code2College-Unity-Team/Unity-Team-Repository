using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hatin : MonoBehaviour
{
    public float speed = 0;

    

    public static int count;
    private float movementX;
    private float movementY;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    private void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void FixedUpdate()
    {
    
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        rb.AddForce(movement * speed);

        if(this.transform.position.y <= -100)
        {
            ScreenMan.isGameOver = true;
        }
        

    }

    

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Saved it!");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        count = data.savedCount;

        Vector3 position;

        position.x = data.savedPosition[0];
        position.y = data.savedPosition[1];
        position.z = data.savedPosition[2];

        transform.position = position;
    }

}
