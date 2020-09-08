using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerLife;      //プレイヤーのライフを格納する変数
    public GameObject PlayerPrefab; //プレイヤーのPrefabを呼び出す際に利用するGameObject
    public Text textGameOver;   //ゲームオーバーの文字を表示するための変数
    public Text textGameClear;  //ゲームクリアの文字を表示するための変数
    private int score;          //スコアを格納する変数
    private float leftTime;     //制限時間を格納する変数
    private Text textScore;     //スコアを文字で表示するための変数
    private Text textLife;      //ライフを文字で表示するための変数
    private Text textTimer;     //制限時間を文字で表示するための変数
    private bool inGame;        //ゲーム中か判断するためのbool型

    public Vector3 Player;      //プレイヤーの座標を取得するため

    GameObject[] WallObject;       //障害物のオブジェクト用配列
    Broken BrokenScript_Wall, BrokenScript_Pipe;    //障害物に割り当てられているBrokenスクリプトを取得するための変数

    GameObject ClearObject;     //textGameClear_flagを使用するための変数
    GameClear GameClearScript;  //クリア判定する際の衝突検知用に割り当てられているGameClearスクリプトを取得するための変数

    // Start is called before the first frame update
    void Start()
    {
        WallObject = GameObject.FindGameObjectsWithTag("Obstacle"); //Collisionflagを使用するため、Obstacleの付いたタグからBrokenスクリプトを取得して変数に格納する

        BrokenScript_Wall = WallObject[0].GetComponent<Broken>(); //Obstacleタグの中にあるBrokenを取得して変数に格納する
        BrokenScript_Pipe = WallObject[1].GetComponent<Broken>(); //Obstacleタグの中にあるBrokenを取得して変数に格納する
        

        ClearObject = GameObject.Find("ClearObject");  //textGameClear_flagを使用するため、ClearObjectと名のついたオブジェクトからGameClearスクリプトを取得して変数に格納する
        GameClearScript = ClearObject.GetComponent<GameClear>(); //ClearObjectと名のついたオブジェクトからGameClearを取得して変数に格納する

        PlayerLife = 3;         //初期プレイヤーライフ
        textGameOver.enabled = false; //ゲームオーバーの文字を非表示
        textGameClear.enabled = false;　//ゲームクリアの文字を非表示
        score = 0;              //初期スコア
        leftTime = 30f;         //制限時間
        textScore = GameObject.Find("Score").GetComponent<Text>();      //テキストスコア
        textLife = GameObject.Find("PlayerLife").GetComponent<Text>();  //テキストライフ
        textTimer = GameObject.Find("Time").GetComponent<Text>();       //テキストタイム
        SetScoreText(score);                //スコアを表示する関数
        SetLifeText(PlayerLife);            //ライフを表示する関数
        inGame = true;          //ゲーム続行中
    }

    //スコアを表示する関数
    private void SetScoreText(int score)
    {
        textScore.text = "Score:" + score.ToString(); 
    }

    //ライフを表示する関数
    private void SetLifeText(int PlayerLife)
    {
        textLife.text = "PlayerLife:" + PlayerLife.ToString();
    }

    //スコアを加算する関数
    public void AddScoreint(int point)
    {
        if (inGame)
        {
            score += point;
            SetScoreText(score);
        }
    }

    //リプレイ用プログラム
    public void Replay()
    {
        SceneManager.LoadScene("stage1");
    }

    

    // Update is called once per frame
    void Update()
    { 
        //プレイヤーの座標を取得
        Player = GameObject.Find("ty@Jumping").transform.position;
        if (inGame)
        {
            //制限時間から経過時間を引く
            leftTime -= Time.deltaTime;
            textTimer.text = "Time:" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");
            //制限時間を超えたら
            if(leftTime < 0f)
            {
                //ゲームオーバーの文字を描画
                textGameOver.enabled = true;
                inGame = false;
            }

            //ゲームクリア用のオブジェクトに触れたら
            if(GameClearScript.textGameClear_flag == true)
            {
                //ゲームクリアの文字を描画
                textGameClear.enabled = true;
                inGame = false;
            }
            //現在のプレイヤーライフをセットする
            SetLifeText(PlayerLife);
            if (PlayerLife <= 0)
            {
             　 PlayerLife = 0;
              　textGameOver.enabled = true;
              　inGame = false;
            }

            //プレイヤーのY座標が設定した値を下回ったら
            if (Player.y <= -30)
            {
                --PlayerLife;
                GameObject newPlayer = Instantiate(PlayerPrefab);
                newPlayer.name = PlayerPrefab.name;
                Destroy(GameObject.Find("ty@Jumping"));
            }
            //障害物に触れたら
            if (BrokenScript_Wall.Collisionflag == true)
            {
                --PlayerLife;
                BrokenScript_Wall.Collisionflag = false;
            }
            //障害物に触れたら
            if (BrokenScript_Pipe.Collisionflag == true)
            {
                --PlayerLife;
                BrokenScript_Pipe.Collisionflag = false;
            }
        }
    }
}
