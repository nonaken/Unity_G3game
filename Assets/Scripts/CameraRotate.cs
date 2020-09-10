using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private  GameObject player;       //プレイヤー格納用
    private  Vector3 offset;         //相対距離取得用


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("ty@Jumping");     //プレイヤーのオブジェクトを読みこむ
        offset = transform.position - player.transform.position;　//カメラの座標からプレイヤー座標を引く
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("ty@Jumping");     //プレイヤーのオブジェクトを読みこむ

        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;    //カメラの座標をプレイヤー座標 + カメラの座標からプレイヤー座標を引いた座標にする

        //プレイヤーの向きをカメラの向きと同じように変更する
        //player.transform.rotation = transform.rotation;


        //Aが押されている時
        if (Input.GetKey(KeyCode.A))
        {
            //プレイヤーを中心に-2f度回転
            transform.RotateAround(player.transform.position, Vector3.up, -2f);
            offset = transform.position - player.transform.position;
        }
        //Dが押されている時
        else if (Input.GetKey(KeyCode.D))
        {
            //プレイヤーを中心に2f度回転
            transform.RotateAround(player.transform.position, Vector3.up, 2f);
            offset = transform.position - player.transform.position;
        }

        //else if (Input.GetKey(KeyCode.R))
        //{
        //    transform.rotation = new Vector3 (transform.rotation,offset,10f); //これが正しい
        //}
        ////Sが押されている時
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    //カメラを中心に2f度回転
        //    transform.RotateAround(player.transform.position, Vector3.right, -2f);
        //    offset = transform.position - player.transform.position;
        //}
        ////Wが押されている時
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    //カメラを中心に2f度回転
        //    transform.RotateAround(player.transform.position,Vector3.right, 2f);
        //    offset = transform.position - player.transform.position;
        //}
    }
}
