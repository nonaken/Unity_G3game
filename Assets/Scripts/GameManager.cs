using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int PlayerLife;
    public GameObject PlayerPrefab;
    public Text textGameOver;
    public int score;
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        PlayerLife = 3;
        textGameOver.enabled = false;
        score = 0;
        textScore = GameObject.Find("Score").GetComponent<Text>();
        SetScoreText(score);
    }
    private void SetScoreText(int score)
    {
        textScore.text = "Score:" + score.ToString(); 
    }

    public void AddScoreint(int point)
    {
        score += point;
        SetScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject PlayerObj = GameObject.Find("ty@Jumping");
        if(PlayerObj == null)
        {
            --PlayerLife;
            if(PlayerLife > 0)
            {
                GameObject newPlayer = Instantiate(PlayerPrefab);
                newPlayer.name = PlayerPrefab.name;
            } else
            {
                PlayerLife = 0;
                textGameOver.enabled = true;
            }
        }
    }
}
