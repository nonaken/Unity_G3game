using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    GameObject ChangeSoundObject;
    Sound SoundScript;

    public UnityEngine.UI.Slider slider;

    private void Start()
    {
       
        ChangeSoundObject = GameObject.Find("GameObject"); //InGameを使用するため、GameObjectからBrokenスクリプトを取得して変数に格納する
        

        SoundScript = ChangeSoundObject.GetComponent<Sound>(); //GameObjectにあるBrokenを取得して変数に格納する
    }

    private void Update()
    { 
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }
    //スライダーで音量調整
    public void OnValueChanged()
    {
        SoundScript.audio.GetComponent<AudioSource>().volume = slider.GetComponent<Slider>().normalizedValue;
    }
}
