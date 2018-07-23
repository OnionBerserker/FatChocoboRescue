using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    bool notDead;
    bool friendNotDead;
    bool levelFinish;
    float currentHP;
    float friendHP;
    public GameObject deathUI;

    private void Awake()
    {
        deathUI.SetActive(false);
    }
    void Start ()
    {
        notDead = PlayerController.character.GetComponent<PlayerController>().alive;
        friendNotDead = Friend.character.GetComponent<Friend>().friendAlive;
        levelFinish = PlayerController.character.GetComponent<PlayerController>().levelComplete;
    }
	
	// Update is called once per frame
	void Update ()
    {
        levelFinish = PlayerController.character.GetComponent<PlayerController>().levelComplete;
        notDead = PlayerController.character.GetComponent<PlayerController>().alive;
        friendNotDead = Friend.character.GetComponent<Friend>().friendAlive;
        if(!levelFinish)
        {
            if (!levelFinish && !notDead || !friendNotDead)
            {
                Cursor.visible = true;
                deathUI.SetActive(true);
            }
        }
    }
}
