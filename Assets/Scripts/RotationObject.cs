using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    //public float rotAngle = 10.0f;
    void FixedUpdate()
    { 
        transform.Rotate(0f,1f, 0f);
    }
}
