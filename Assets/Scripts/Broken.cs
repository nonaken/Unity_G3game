using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    public GameObject PlayerPrefab;

    void Start()
    {

    }
   
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Human")
        {
            //GameObject Human_Obj =  GameObject.Find("ty@Jumping");
            //--PlayerLife;
            Destroy(gameObject, 0.1f);

            GameObject newPlayer = Instantiate(PlayerPrefab);
            newPlayer.name = PlayerPrefab.name;
            Destroy(GameObject.Find("ty@Jumping"));
        }
    }
}
