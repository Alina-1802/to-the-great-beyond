using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed = 0.001f;
    void Update()
    {
        transform.Rotate(0,speed,0);
    }
}
