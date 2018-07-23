using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static GameObject character;
    public GameObject chocoboModel;
    public GameObject goalUI;

    public bool alive;
    public bool enemyStunned;
    public bool vulnerable;
    public float invulTime;
    public float maxInvulTime;
    public float damage;
   
    public bool levelComplete;
    public float speed;
    public float dashPower;
    public ForceMode forceMode;

    private int facingDirection; // 0 = foward; 1 = left; 2 = right; 3 = back
    private bool dashing;
    private FacingDirection dir;
    
    private bool moveFoward;
    private bool moveLeft;
    private bool moveRight;
    private bool moveBack;

    private Rigidbody rigidBody;

    public float dashMeter;
    public float dashRefuel;
    public float health = 100f;
    private float friendHP;
    private float maxHealth;
    private float maxFriendHP;

    public bool lavaTouch;

    bool onBadGround;
   public bool playerSpotted;

    void Awake()
    {
        alive = true;
        rigidBody = GetComponent<Rigidbody>();
        character = gameObject;
    }

    void Start()
    {

        Cursor.visible = false;
        facingDirection = 0;
        vulnerable = true;
        maxInvulTime = 1.5f;
        invulTime = maxInvulTime;
        dashMeter = 10;
        dashRefuel = .80f;
        health = 100;
        maxHealth = health;
        friendHP = Friend.character.GetComponent<Friend>().friendHealth;
        maxFriendHP = friendHP;
        playerSpotted = false;
        //enemyForce = 10000;
        GameObject thePlayer = GameObject.Find("Chocobo");
        dir = thePlayer.GetComponent<FacingDirection>();
        goalUI.SetActive(false);
    }

    void Update()
    {
        facingDirection = dir.GetDirection();
        friendHP = Friend.character.GetComponent<Friend>().friendHealth;
        levelComplete = Friend.character.GetComponent<Friend>().goalReached;
        //Movement===========================================
        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            moveFoward = true;
        }
        if (Input.GetKeyUp("up") || Input.GetKeyUp("w"))
        {
            moveFoward = false;
        }
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            moveLeft = true;
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("a"))
        {
            moveLeft = false;
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            moveRight = true;
        }
        if (Input.GetKeyUp("right") || Input.GetKeyUp("d"))
        {
            moveRight = false;
        }
        if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            moveBack = true;
        }
        if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
            moveBack = false;
        //====================================================
        //Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashMeter > 5)
            {
                dashing = true;
                dashMeter -= 3f;
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            dashing = false;
        }
        if (dashMeter < 10)
        {
            dashMeter = dashMeter + dashRefuel * Time.fixedDeltaTime;
        }
        //====================================================
        //Enviroment Interaction==============================
        /*if (onBadGround)
        {
            health -= Time.fixedDeltaTime;
        }*/
        if (lavaTouch)
        {
            health -= 5*Time.fixedDeltaTime;
        }

        //====================================================
        if (health <= 0)
        {
            if (!levelComplete)
            {
                alive = false;
            }
        }
        if (levelComplete && alive)
        {
            Cursor.visible = true;
            goalUI.SetActive(true);
        }
        if(!vulnerable)
        {
            if(invulTime <= 0)
            {
                chocoboModel.GetComponent<Renderer>().material.color = Color.yellow;
                vulnerable = true;
            }
            invulTime -= Time.fixedDeltaTime;
        }
    }

    void FixedUpdate()
    {
        //Movement===============================================================================
        if (moveFoward)
        {
            Vector3 newPosition = Vector3.forward;
            rigidBody.MovePosition(rigidBody.position + newPosition * speed * Time.deltaTime);
            if (dashing && facingDirection == 0)
            {
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
            }                
        }
        if (moveLeft)
        {
            Vector3 newPosition = Vector3.left;
            
            rigidBody.MovePosition(rigidBody.position + newPosition * speed * Time.deltaTime);
            if (dashing && facingDirection == 1)
            {
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
            }
        }
        if (moveRight)
        {
            Vector3 newPosition = Vector3.right;
            rigidBody.MovePosition(rigidBody.position + newPosition * speed * Time.deltaTime);
            if (dashing && facingDirection == 2)
            {
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
            }
        }
        if (moveBack)
        {
            Vector3 newPosition = Vector3.back;
            rigidBody.MovePosition(rigidBody.position + newPosition * speed * Time.deltaTime);
            if (dashing && facingDirection == 3)
            {
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
            }
        }
        if(!moveFoward && !moveLeft && !moveRight && !moveBack && dashing)
        {
            if (facingDirection == 0)
            {
                Vector3 newPosition = Vector3.forward;
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
            }
            if(facingDirection == 1)
            {
                Vector3 newPosition = Vector3.left;
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
                
            }
            if (facingDirection == 2)
            {
                Vector3 newPosition = Vector3.right;
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
            }
            if (facingDirection == 3)
            {
                Vector3 newPosition = Vector3.back;
                rigidBody.AddForce(newPosition * dashPower * Time.deltaTime, forceMode);
                dashing = false;
            }
        }
        //=======================================================================================
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "BadGround" && collision.gameObject.tag != "EnemyField" && collision.gameObject.tag != "LavaGround")
        {
            lavaTouch = false;
        }
        if (collision.gameObject.tag == "EnemyField")
        {
            playerSpotted = true;
        }
        if (collision.gameObject.tag != "EnemyField")
        {
            playerSpotted = false;
        }
        if (collision.gameObject.tag == "LavaGround")
        {
            lavaTouch = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(!levelComplete)
        {
            if (collision.gameObject.tag == "DeathPlane")
            {
                Debug.Log("death");
                alive = false;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (vulnerable)
            {
                health -= 25;
                vulnerable = false;
                chocoboModel.GetComponent<Renderer>().material.color = Color.red;
                invulTime = 1.5f;
            }
        }
        if (collision.gameObject.tag == "Boss")
        {
            if (EnemyAI_Boss.enemyRef.GetComponent<EnemyAI_Boss>().damage > 0)
            {
                health -= 50;
                vulnerable = false;
                chocoboModel.GetComponent<Renderer>().material.color = Color.red;
                invulTime = 1.5f;
            }
        }
    }
}
