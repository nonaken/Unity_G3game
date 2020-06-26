using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    Vector3 target = new Vector3(0f, 1f, -50f);

    float speed = 20.0f;

    void Start()
    {

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if (transform.position.z <= -50f)
        {
            transform.position = new Vector3(0f,0f,0f);
        }

        //if(target.x >= -50)
        //{
        //    target.x = 0;
        //}

        //if (transform.position == target)
        //{
        //   GameObject.Find("")
        //}
    }
}
