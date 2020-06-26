using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Jumping : MonoBehaviour
{

    void Update()
    {

        Animator anim = GetComponent<Animator>();

        // 何かキーが押されている
        if (Input.GetKey("space"))
        {
            anim.SetBool("jump_flag", true);
        }
        else
        {
            anim.SetBool("jump_flag", false);
        }
    }
}
