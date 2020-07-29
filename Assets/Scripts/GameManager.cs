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
    private int score;
    private float leftTime;
    private Text textScore;
    private Text textLife;
    private Text textTimer;
    private bool inGame;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerLife = 3;
        textGameOver.enabled = false;
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
        if (inGame)
        {
            leftTime -= Time.deltaTime;
            textTimer.text = "Time:" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");
            if(leftTime < 0f)
            {
                textGameOver.enabled = true;
                inGame = false;
            }
            
            GameObject PlayerObj = GameObject.Find("ty@Jumping");
            if (PlayerObj == null)
            {
                --PlayerLife;
                SetLifeText(PlayerLife);
                if (PlayerLife > 0)
                {
                    GameObject newPlayer = Instantiate(PlayerPrefab);
                    newPlayer.name = PlayerPrefab.name;
                }
                else
                {
                    PlayerLife = 0;
                    textGameOver.enabled = true;
                    inGame = false;
                }
            }
        }
    }
}
