using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRotate : MonoBehaviour
{
    public float rotationSpeed = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30, 60, 45) * Time.deltaTime * rotationSpeed);
    }
}
