using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyController : MonoBehaviour
{
    public float timer = 0;
    public float reset = 0;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= reset)
        {
            timer = 0;
        }
    }
}
