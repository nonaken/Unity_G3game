using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public bool textGameClear_flag; //ゲームクリアか判断するためのbool型
    // Start is called before the first frame update
    void Start()
    {
        textGameClear_flag = false; //ゲームクリアではない
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //Humanのタグが付いたオブジェクトが触れたら
        if (other.gameObject.tag == "Human")
        {
            textGameClear_flag = true; //ゲームクリア
        }
    }
}
