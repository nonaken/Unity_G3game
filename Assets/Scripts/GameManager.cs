using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerLife;
    public GameObject PlayerPrefab;
    public Text textGameOver;
    public Text textGameClear;
    private int score;
    private float leftTime;
    private Text textScore;
    private Text textLife;
    private Text textTimer;
    private bool inGame;

    public Vector3 Player;

    GameObject PlayerObject;
    Broken BrokenScript;

    GameObject ClearObject;
    GameClear GameClearScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindWithTag("Obstacle"); //PlayerLifeを使用しているオブジェクトの名前から取得して変数に格納する
        BrokenScript = PlayerObject.GetComponent<Broken>(); //PlayerObjectの中にあるBrokenを取得して変数に格納する

        ClearObject = GameObject.Find("ClearObject");
        GameClearScript = ClearObject.GetComponent<GameClear>();

        PlayerLife = 3;
        textGameOver.enabled = false;
        textGameClear.enabled = false;
        score = 0;
        leftTime = 30f;
        textScore = GameObject.Find("Score").GetComponent<Text>();
        textLife = GameObject.Find("PlayerLife").GetComponent<Text>();
        textTimer = GameObject.Find("Time").GetComponent<Text>();
        SetScoreText(score);
        SetLifeText(PlayerLife);
        inGame = true;
    }

    private void SetScoreText(int score)
    {
        textScore.text = "Score:" + score.ToString(); 
    }

    private void SetLifeText(int PlayerLife)
    {
        textLife.text = "PlayerLife:" + PlayerLife.ToString();
    }

    public void AddScoreint(int point)
    {
        if (inGame)
        {
            score += point;
            SetScoreText(score);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("stage1");
    }

    

    // Update is called once per frame
    void Update()
    { 
        Player = GameObject.Find("ty@Jumping").transform.position;
        if (inGame)
        {
            leftTime -= Time.deltaTime;
            textTimer.text = "Time:" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");
            if(leftTime < 0f)
            {
                textGameOver.enabled = true;
                inGame = false;
            }

            if(GameClearScript.textGameClear_flag == true)
            {
                textGameClear.enabled = true;
                inGame = false;
            }

            //GameObject PlayerObj = GameObject.Find("ty@Jumping");

            //if (PlayerObj == null)
            //{
            //    --PlayerLife;
            //}
                SetLifeText(PlayerLife);
            //if (PlayerLife > 0)
            //{
            //    GameObject newPlayer = Instantiate(PlayerPrefab);
            //    newPlayer.name = PlayerPrefab.name;
            //}

                if (PlayerLife <= 0)
                {
                    PlayerLife = 0;
                    textGameOver.enabled = true;
                    inGame = false;
                }
            //}
            if (Player.y <= -30)
            {
                --PlayerLife;
                GameObject newPlayer = Instantiate(PlayerPrefab);
                newPlayer.name = PlayerPrefab.name;
                Destroy(GameObject.Find("ty@Jumping"));
            }
            if (BrokenScript.Collisionflag == true)
            {
                --PlayerLife;
                BrokenScript.Collisionflag = false;
            }
        }
    }
}
