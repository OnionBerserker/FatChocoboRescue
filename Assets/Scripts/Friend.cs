using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour {

    public static GameObject character;
    public GameObject friendModel;

    public float friendHealth;
    public bool friendAlive;
    public bool vulnerable;
    public float invulTime;
    public bool onBadGround;
    public bool onLavaGround;
    public bool goalReached;

    void Awake()
    {
        character = gameObject;
    }
    private void Start()
    {
        goalReached = false;
        friendAlive = true;
        vulnerable = true;
        invulTime = 1.5f;
    }

    void Update ()
    {
		if(onBadGround)
        {
            friendHealth -= Time.deltaTime;
        }
        if(onLavaGround)
        {
            friendHealth -= Time.deltaTime * 5f;
        }
        if (friendHealth <= 0 )
        {
            friendAlive = false;
        }
        if (!vulnerable)
        {
            if(invulTime <= 0)
            {
                friendModel.GetComponent<Renderer>().material.color = Color.yellow;
                vulnerable = true;
            }
            invulTime -= Time.fixedDeltaTime;  
        }
	}
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "BadGround" || collision.gameObject.tag == "EnemyField")
        {
            onBadGround = true;
        }
        if (collision.gameObject.tag != "BadGround" && collision.gameObject.tag != "EnemyField" && collision.gameObject.tag != "LavaGround")
        {
            onBadGround = false;
            onLavaGround = false;
        }
        if (collision.gameObject.tag == "LavaGround")
        {
            onLavaGround = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (friendAlive)
                goalReached = true;
        }
        if (collision.gameObject.tag == "DeathPlane")
        {
            friendAlive = false;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            if (vulnerable)
            {
                friendHealth -= 25;
                vulnerable = false;
                friendModel.GetComponent<Renderer>().material.color = Color.red;
                invulTime = 1.5f;
            }
        }
        if (collision.gameObject.tag == "Boss")
        {
            if (vulnerable)
            {
                if (EnemyAI_Boss.enemyRef.GetComponent<EnemyAI_Boss>().damage > 0)
                {
                    friendHealth -= 50;
                    vulnerable = false;
                    friendModel.GetComponent<Renderer>().material.color = Color.red;
                    invulTime = 1.5f;
                } 
            }
        }
    }
}
