using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI 関連クラスを使用する宣言
using UnityEngine.UI;

public class Animation_Jumping : MonoBehaviour
{
    // Rigidbod コンポーネントを格納する変数
    public Rigidbody rb;
    // ジャンプ力：Rigidbod コンポーネントに加える力を格納する変数
    private float jumpPower = 8f;
    // ジャンプ有効フラグ
    public bool jump = true;

    //床に触れているか判断するためのbool型
    public bool floor;

    //Animatorを読みこむ
    private Animator animator;

    // ゲーム開始時の処理
    void Start()
    {
        animator = GetComponent<Animator>();　
        rb = GetComponent<Rigidbody>();//  rbにRigidbodyの値を代入する
    }

    // ゲーム実行中に一定タイミングで実行される処理
    private void FixedUpdate()
    {
        // ジャンプ有効フラグが true の場合
        if (jump)
        {
            // Rigidbod コンポーネントに力を加える
            //  ForceMode.Impulse で瞬時に衝撃力を適用
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            //anim.transform.position += jumpPower;
            // ジャンプ有効フラグを false に設定
            jump = false;
        }
    }

    // ゲーム実行中に毎フレーム実行される処理
    void Update()
    {

        

        // オブジェクトのジャンプ高さの抑制
        // Rigidbody コンポーネントのY座標が 1.2f 以下であれば
        //if (rb.position.y < 1.2f)
        //{
           //floorフラグがtrueのとき
            if (floor == true)
            {
                //スペースキーが押されている
                if (Input.GetKey("space"))
                {
                   animator.SetBool("jump_flag", true);
                   floor = false;
                    // ジャンプ有効フラグを true に設定
                   jump = true;
                }

                else
                {
                   animator.SetBool("jump_flag", false);
                }
            //}
        }
    }
    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "floor")//  もしfloorというタグがついたオブジェクトに触れたら、
        {
            floor = true;//  floorをtrueにする
        }
        else
        {
            floor = false;//  floorをfasleにする
        }
    }
}