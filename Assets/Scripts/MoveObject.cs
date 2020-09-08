using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    Vector3 target = new Vector3(0f, 1f, -50f);

    float speed = 20.0f;    //障害物オブジェクトのスピード

    void Start()
    {

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step); //移動処理

        ///障害物のZ座標が設定した値を上回ったら
        if (transform.position.z <= -50f)
        {
            //設定した座標に戻す
            transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}
