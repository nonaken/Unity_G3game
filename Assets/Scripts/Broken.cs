using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    public bool Collisionflag; //プレイヤーが衝突しているか判断するためのbool型

    void Start()
    {
        Collisionflag = false;
    }
   
   　//衝突処理
    void OnCollisionEnter(Collision other)
    {
        //Humanのタグが付いたオブジェクトが触れたら
        if(other.gameObject.tag == "Human")
        {
            Destroy(gameObject, 0.1f); //触れた障害物のオブジェクトを消す
            Collisionflag = true;
        }
        else {
            Collisionflag = false;
        }
    }
}
