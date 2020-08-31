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
    private float jumpPower;
    // ジャンプ：KeyCode を格納する変数
    public KeyCode key;
    // UI Toggle コンポーネントを格納する変数
    public Toggle toggle;
    // UI Text コンポーネントを格納する変数
    public Text toggleLabel;
    // ジャンプ有効フラグ
    private bool jump;

    // ゲーム開始時の処理
    void Start()
    {
        // 関数 ToggleChange() を実行
        ToggleChange();
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
            // ジャンプ有効フラグを false に設定
            jump = false;
        }
    }

    // ゲーム実行中に毎フレーム実行される処理
    void Update()
    {
        //Animator anim = GetComponent<Animator>();

        // 何かキーが押されている
        //if (Input.GetKey("space"))
        //{
        //    anim.SetBool("jump_flag", true);
        //}

        //else
        //{
        //    anim.SetBool("jump_flag", false);
        //}

        // オブジェクトのジャンプ高さの抑制
        // Rigidbod コンポーネントのY座標が 1.2f 以下であれば
        if (rb.position.y < 1.2f)
        {
            // 変数 key に格納したキーを押し続けている間、
            // かつUI Toggle コンポーネントの isOn が false であれば
            // または
            // 変数 key に格納したキー入力があれば、
            // かつUI Toggle コンポーネントの isOn が true であれば
            if ((Input.GetKey(key) && !toggle.isOn) || (Input.GetKeyDown(key) && toggle.isOn))
            {
                // ジャンプ有効フラグを true に設定
                jump = true;
            }
        }
    }

    // UI Toggle コンポーネントの 値が変更された場合に実行する処理
    public void ToggleChange()
    {
        // UI Toggle コンポーネントの isOn が false であれば
        if (!toggle.isOn)
        {
            // Text コンポーネントの text に "GetKey" を格納
            toggleLabel.text = "GetKey:キー押時間でジャンプ力調整";
            // ジャンプ力の変数 jumpPower に 1f を入力
            jumpPower = 1f;
        }
        // UI Toggle コンポーネントの isOn が true であれば
        if (toggle.isOn)
        {
            // Text コンポーネントの text に "GetKeyDown" を格納
            toggleLabel.text = "GetKeyDown:ジャンプ力一定";
            // ジャンプ力の変数 jumpPower に 8f を入力
            jumpPower = 8f;
        }
    }
}
    //void Update()
    //{
    //    Animator anim = GetComponent<Animator>();

    //    // 何かキーが押されている
    //    if (Input.GetKey("space"))
    //    {
    //        anim.SetBool("jump_flag", true);
    //    }

    //    else
    //    {
    //        anim.SetBool("jump_flag", false);
    //    }

    //}