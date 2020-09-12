using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public static class DefinePause
{
    // static readonlyの場合
    public static readonly int ImageNumber = 3;      //障害物のオブジェクト数(マクロ定義のようなもの)
}

public class Pause : MonoBehaviour
{
    [SerializeField]
    public GameObject[] pauseUI;    //ポーズした時に表示するUI
    public Image[] image;           //ポーズした時に表示するUIのImage配列(enabledを使用するため)

    private void Start()
    {
        for (int i = 0; i < DefinePause.ImageNumber; i++)
        {
            image[i].enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < DefinePause.ImageNumber; i++)
            {
                //　ポーズUIのアクティブ、非アクティブを切り替え
                pauseUI[i].SetActive(!pauseUI[i].activeSelf);

                //　ポーズUIが表示されてる時は停止
                if (pauseUI[i].activeSelf == true)
                {

                    image[i].enabled = true;

                    Time.timeScale = 0f;
                }
                //　ポーズUIが表示されてなければ通常通り進行
                else
                {
                    Time.timeScale = 1f;
                }

            }


        }
    }
}