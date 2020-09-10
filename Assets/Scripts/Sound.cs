using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip sound01;

    GameObject SoundObject;       //障害物のオブジェクト用配列
    GameManager GameManagerScript_Sound;  //障害物に割り当てられているBrokenスクリプトを取得するための変数

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        SoundObject = GameObject.Find("GameObject"); //InGameを使用するため、GameObjectからBrokenスクリプトを取得して変数に格納する

        GameManagerScript_Sound = SoundObject.GetComponent<GameManager>(); //GameObjectにあるBrokenを取得して変数に格納する
        audio.clip = sound01;
        audio.volume = 0.1f;
        
        audio.PlayOneShot(sound01);
       

    }
    private void Update()
    {
       
        //ゲーム中なら
        if (GameManagerScript_Sound.inGame == false)
        {
            //ミュートにする
            audio.mute = true;
        }
    }
}