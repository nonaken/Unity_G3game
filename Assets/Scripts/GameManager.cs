using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int PlayerLife;
    public GameObject PlayerPrefab;
    public Text textGameOver;

    // Start is called before the first frame update
    void Start()
    {
        PlayerLife = 3;
        textGameOver.enabled = false;
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
