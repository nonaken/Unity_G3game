using UnityEngine;
using System.Collections;


public class ChangeColor : MonoBehaviour
{
   
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball" )
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}