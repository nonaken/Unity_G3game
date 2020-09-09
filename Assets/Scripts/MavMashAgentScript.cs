using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MavMashAgentScript : MonoBehaviour
{
    public NavMeshAgent agent;          //☆追加
    public GameObject target;           //☆追加  目的地

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("ty@Jumping");
        //目的地を設定してあげる
        agent.SetDestination(target.transform.position);

    }
}