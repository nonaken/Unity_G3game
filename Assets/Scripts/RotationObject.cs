using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    //public float rotAngle = 10.0f;
    void Update()
    { 
        transform.Rotate(0f,60f * Time.deltaTime, 0f);
    }
}
