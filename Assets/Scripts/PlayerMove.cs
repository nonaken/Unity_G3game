using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public float rotateSpeed;
    public float speed = 10.0f;     //キャラクターの移動速度

    //外部から値が変わらないようにPrivateで定義
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ////jump_flagがfalseなら
        //if (animator.GetBool("jump_flag") == false)
        //{
            //方向転換
            //方向キーのどちらも押されている時
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                //向きを変えない
                animator.SetBool("run_flag", false);
            }

            //上矢印キーを押している間
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                //キャラクターの向きを上方向にする
                transform.rotation = Quaternion.AngleAxis(0, new Vector3(1, 0, 0));
                //歩くアニメーションフラグをtrueにする
                animator.SetBool("run_flag", true);
                //キャラクターの移動
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            else if(Input.GetKey(KeyCode.DownArrow))
            {
                //キャラクターの向きを上方向にする
                transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
                //歩くアニメーションフラグをtrueにする
                animator.SetBool("run_flag", true);
                //キャラクターの移動
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            //左方向キーが押されている時
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //キャラクターの向きを左方向にする
                transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 1, 0));
                //transform.Rotate(0, rotateSpeed * -1, 0);
                //歩くアニメーションフラグをtrueにする
                animator.SetBool("run_flag", true);
                //キャラクターの移動
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            //右方向キーが押されている時
            else if (Input.GetKey(KeyCode.RightArrow))
            {  
                //キャラクターの向きを右方向にする
                transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
                //歩くアニメーションフラグをtrueにする
                animator.SetBool("run_flag", true);
                //キャラクターの移動
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            else
            {
                //歩くアニメーションフラグをfalseにする
                animator.SetBool("run_flag", false);
            }
        //}
    }
}
