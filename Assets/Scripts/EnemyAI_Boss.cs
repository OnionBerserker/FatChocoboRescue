using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_Boss : MonoBehaviour {

    public GameObject enemy;

    public static GameObject enemyRef;

    public float damage;
   
    public Transform defltPos;
    public Transform PlayerPos;

    bool stunned;
    public float stunTime;
    public float maxStun;

    //Rigidbody rb;

    bool playerDetect;

    private void Awake()
    {
        
    }

    void Start()
    {
        playerDetect = PlayerController.character.GetComponent<PlayerController>().playerSpotted;
        enemyRef = gameObject;
        stunned = false;
        maxStun = 2.0f;
        damage = 50;
        stunTime = maxStun;
    }

    // Update is called once per frame
    void Update()
    {
        playerDetect = PlayerController.character.GetComponent<PlayerController>().playerSpotted;
        if (!stunned)
        {
            if (!playerDetect)
            {
                var agent = GetComponent<NavMeshAgent>();
                agent.SetDestination(defltPos.position);
            }
            if (playerDetect)
            {
                var agent = GetComponent<NavMeshAgent>();
                agent.SetDestination(PlayerPos.position);
            }
        }
        if (stunned)
        {
            if (stunTime <= 0)
            {
                enemy.GetComponent<Renderer>().material.color = Color.red;
                stunned = false;
                damage = 50;
            }
            stunTime -= Time.fixedDeltaTime;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            if (!stunned)
            {
                damage = 0;
                enemy.GetComponent<Renderer>().material.color = Color.blue;
                stunTime = maxStun;
                stunned = true;
            }
        }
    }
}
