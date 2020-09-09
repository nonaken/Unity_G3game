using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;

    GameObject SoundObject;       //障害物のオブジェクト用配列
    GameManager GameManagerScript_Sound;  //障害物に割り当てられているBrokenスクリプトを取得するための変数

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        SoundObject = GameObject.Find("GameObject"); //Collisionflagを使用するため、Obstacleの付いたタグからBrokenスクリプトを取得して変数に格納する

        GameManagerScript_Sound = SoundObject.GetComponent<GameManager>(); //Obstacleタグの中にあるBrokenを取得して変数に格納する
        audio.PlayOneShot(sound01);
    }
    private void Update()
    {
        if (GameManagerScript_Sound.inGame == false)
        {
            
            audio.mute = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Block"){
            audio.PlayOneShot(sound02);
        }
        else audio.PlayOneShot(sound03);
    }
}