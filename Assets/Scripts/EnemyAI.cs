using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour {

    public GameObject enemy;
   // public static GameObject enemyRef;
    public GameObject bulletPrefab;

    public float damage;

    public Transform defltPos;
    public Transform PlayerPos;
    public Transform bulletSpawn;

    public bool stunned;
    public float stunTime;
    public float maxStun;
    public float fireRate;
    public float waitTime;

    //Rigidbody rb;

    bool playerDetect;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        //enemy = gameObject;
    }

    void Start ()
    {
        playerDetect = PlayerController.character.GetComponent<PlayerController>().playerSpotted;
        stunned = false;
        maxStun = 5f;
        damage = 25;
        stunTime = maxStun;
        fireRate = 3;
        waitTime = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerDetect = PlayerController.character.GetComponent<PlayerController>().playerSpotted;
        if(!stunned)
        {
            if (!playerDetect)
            {
                var agent = GetComponent<NavMeshAgent>();
                agent.SetDestination(defltPos.position);
                CancelInvoke();
            }
            if (playerDetect)
            {
                var agent = GetComponent<NavMeshAgent>();
                agent.SetDestination(PlayerPos.position);
                InvokeRepeating("Fire", waitTime, fireRate);

            }
        }
    }
    void Fire()
    {
        var bullet = (GameObject)Instantiate(
           bulletPrefab,
           bulletSpawn.position,
           bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 40;

        Destroy(bullet, .25f);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            CancelInvoke();
            enemy.SetActive(false);
        }
    }
}
