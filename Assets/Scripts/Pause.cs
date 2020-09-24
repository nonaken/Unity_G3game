using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public static class DefinePause
{
    // static readonlyの場合
    public static readonly int ImageNumber = 2;      //障害物のオブジェクト数(マクロ定義のようなもの)
}

public class Pause : MonoBehaviour
{
    [SerializeField]
    public GameObject[] pauseUI;    //ポーズした時に表示するUI
    public Image[] image;           //ポーズした時に表示するUIのImage配列(enabledを使用するため)
    public Slider slider;           //スライダーを表示するため
  

    private void Start()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < DefinePause.ImageNumber; i++)
        {
            image[i].enabled = false;
        }
        slider.enabled = false;     //スライダーを非表示にする
    }
    // Update is called once per frame
    //void Update()
    public void PauseImage()
    {
        slider.gameObject.SetActive(!slider.gameObject.activeSelf);
        ////エスケープキーを押したら
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //}
        for (int i = 0; i < DefinePause.ImageNumber; i++)
        {
                //　ポーズUIのアクティブ、非アクティブを切り替え
                pauseUI[i].SetActive(!pauseUI[i].activeSelf);
                
                //　ポーズUIが表示されてる時は停止
                if (pauseUI[i].activeSelf == true)
                {

                    image[i].enabled = true;
                    slider.enabled = true;

                    Time.timeScale = 0f;
                }
                //　ポーズUIが表示されてなければ通常通り進行
                else
                {
                    slider.enabled = false;
                    Time.timeScale = 1f;
                }


        }
    }
}