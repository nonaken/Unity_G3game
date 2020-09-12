using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Define
{
    // static readonlyの場合
    public static readonly int ObstacleNumber = 2;      //障害物のオブジェクト数(マクロ定義のようなもの)
    public static readonly int HeelObjectNunmber = 3;   //回復のオブジェクト数(マクロ定義のようなもの)
    public static readonly int PlayerKill_Y = -30;      //プレイヤーのY座標が設定した値になったらライフを減らす(マクロ定義のようなもの)
}

public class GameManager : MonoBehaviour
{
    public int PlayerLife;      //プレイヤーのライフを格納する変数
    public GameObject PlayerPrefab; //プレイヤーのPrefabを呼び出す際に利用するGameObject

    public Text textGameOver;   //ゲームオーバーの文字を表示するための変数
    public Text textGameClear;  //ゲームクリアの文字を表示するための変数

    private int score;          //スコアを格納する変数
    private int ScorePoint = 50;
    private float leftTime;     //制限時間を格納する変数

    private Text textScore;     //スコアを文字で表示するための変数
    private Text textLife;      //ライフを文字で表示するための変数
    private Text textTimer;     //制限時間を文字で表示するための変数
    public bool inGame;        //ゲーム中か判断するためのbool型

    public Vector3 Player;      //プレイヤーの座標を取得するため

    GameObject[] ObstacleObject;       //障害物のオブジェクト用配列
    Broken[] BrokenScript_Obstacle;    //障害物に割り当てられているBrokenスクリプトを取得するための配列

    GameObject[] HeelObject;            //回復オブジェクト用配列
    Broken[] BrokenScript_Heel;         //回復オブジェクトに割り当てられているBrokenスクリプトを取得するための配列

    GameObject ClearObject;     //textGameClear_flagを使用するための変数
    GameClear GameClearScript;  //クリア判定する際の衝突検知用に割り当てられているGameClearスクリプトを取得するための変数

    // Start is called before the first frame update
    void Start()
    { 
        ObstacleObject = GameObject.FindGameObjectsWithTag("Obstacle"); //Collisionflagを使用するため、Obstacleの付いたタグからBrokenスクリプトを取得して変数に格納する
        HeelObject = GameObject.FindGameObjectsWithTag("Heel");                    //Collisionflagを使用するため、Heelの付いたタグからBrokenスクリプトを取得して変数に格納する

        BrokenScript_Obstacle = new Broken[Define.HeelObjectNunmber];       //NullReferenceException解消
        BrokenScript_Heel = new Broken[Define.HeelObjectNunmber];       //NullReferenceException解消
       
        //障害物のオブジェクトを読み込む
        for (int i = 0; i < Define.ObstacleNumber; i++)
        {
            BrokenScript_Obstacle[i] = ObstacleObject[i].GetComponent<Broken>(); //Obstacleタグの中にあるBrokenを取得して変数に格納する    
        }
        //回復オブジェクトを読み込む
        for (int i = 0; i < Define.HeelObjectNunmber; i++)
        {
            BrokenScript_Heel[i] = HeelObject[i].GetComponent<Broken>();        //Heelタグの中にあるBrokenを取得して変数に格納する
        }

        ClearObject = GameObject.Find("ClearObject");  //textGameClear_flagを使用するため、ClearObjectと名のついたオブジェクトからGameClearスクリプトを取得して変数に格納する
        GameClearScript = ClearObject.GetComponent<GameClear>(); //ClearObjectと名のついたオブジェクトからGameClearを取得して変数に格納する

        PlayerLife = 3;         //初期プレイヤーライフ
        textGameOver.enabled = false; //ゲームオーバーの文字を非表示
        textGameClear.enabled = false;　//ゲームクリアの文字を非表示
        score = 0;              //初期スコア
        leftTime = 60f;       //制限時間
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
        //タイトル画面のとき
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
            if (Player.y <= Define.PlayerKill_Y)
            {
                --PlayerLife;
                GameObject newPlayer = Instantiate(PlayerPrefab);
                newPlayer.name = PlayerPrefab.name;
                Destroy(GameObject.Find("ty@Jumping"));
            }

            //障害物のオブジェクトごとの衝突判定
            for (int i = 0; i < Define.ObstacleNumber; i++)
            {
                //障害物に触れたら
                if (BrokenScript_Obstacle[i].Collisionflag == true)
                {
                    --PlayerLife;
                    AddScoreint(-ScorePoint);
                    BrokenScript_Obstacle[i].Collisionflag = false;
                }
            }
            //回復オブジェクトごとの衝突判定
            for (int i = 0; i < Define.HeelObjectNunmber; i++)
            {
                //回復アイテムに触れたら
                if (BrokenScript_Heel[i].Collisionflag == true)
                {
                    ++PlayerLife;
                    AddScoreint(ScorePoint);
                    BrokenScript_Heel[i].Collisionflag = false;
                }
            }
        }
    }
}
