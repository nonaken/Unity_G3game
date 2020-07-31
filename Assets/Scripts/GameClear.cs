using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public bool textGameClear_flag;
    // Start is called before the first frame update
    void Start()
    {
        textGameClear_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Human")
        {
            textGameClear_flag = true;
            //Debug.Log(other.gameObject.name);
        }
    }
}
