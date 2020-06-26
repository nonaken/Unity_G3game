using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private GameObject player;       //プレイヤー格納用
    private Vector3 offset;          //相対距離取得用
   

    // Use this for initialization
    void Start()
    {
        //プレイヤーをplayerに格納
        player = GameObject.Find("ty@Jumping");
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //新しいトランスフォームの値を代入する
        //transform.position = player.transform.position + offset;

        //プレイヤーの向きと同じようにカメラの向きを変更する
        //transform.rotation = player.transform.rotation;

        //Aが押されている時
        if (Input.GetKey(KeyCode.A))
        {
            //プレイヤーを中心に-2f度回転
            transform.RotateAround(player.transform.position, Vector3.up, -2f);
        }
        //Dが押されている時
        else if (Input.GetKey(KeyCode.D))
        {
            //プレイヤーを中心に2f度回転
            transform.RotateAround(player.transform.position, Vector3.up, 2f);
        }
        ////Sが押されている時
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    //カメラを中心に2f度回転
        //    transform.RotateAround(player.transform.position, Vector3(1,0,0), 2f);
        //}
        //Wが押されている時
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    //カメラを中心に2f度回転
        //    transform.RotateAround(Vector3.up, player.transform.position, 2f);
        //}
    }
}
