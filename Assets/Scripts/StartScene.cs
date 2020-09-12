using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        
        SceneManager.LoadScene("stage1");
        Time.timeScale = 1f;
        
    }
}
