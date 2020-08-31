using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public bool Collisionflag;

    void Start()
    {
        Collisionflag = false;
    }
   
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Human")
        {
            //GameObject Human_Obj =  GameObject.Find("ty@Jumping");
            //GameManager G1 = PlayerPrefab.GetComponent<GameManager>();
           
            Destroy(gameObject, 0.1f);
            //++PlayerLife_count;
            Collisionflag = true;


            //GameObject newPlayer = Instantiate(PlayerPrefab);
            //newPlayer.name = PlayerPrefab.name;
            //Destroy(GameObject.Find("ty@Jumping"));
        }
        else {
            Collisionflag = false;
        }
    }
}
