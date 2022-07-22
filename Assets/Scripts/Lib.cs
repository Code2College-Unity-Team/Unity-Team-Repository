using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public static class Lib
{
    public static Quaternion VectorToQuadernion(Vector3 v)
    {
        return Quaternion.Euler(v.x, v.y, v.z);
    }
}