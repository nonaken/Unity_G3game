using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Human")
        {
            GameObject Human_Obj =  GameObject.Find("ty@Jumping");
            Destroy(gameObject, 0.1f);
            Destroy(GameObject.Find("ty@Jumping"), 0.1f);
        }
    }
}
