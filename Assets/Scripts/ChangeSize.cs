using UnityEngine;
using System.Collections;
public class ChangeSizeBlock : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball"){
            GetComponent<Transform>().localScale =
            new Vector3(1 / 2f, 1.0f, 1 / 2f);
        }
    }
}