using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendHealth : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;
    public GameObject friendHealth;

	void Start ()
    {
        maxHealth = Friend.character.GetComponent<Friend>().friendHealth;
	}

	void FixedUpdate ()
    {
		currentHealth = Friend.character.GetComponent<Friend>().friendHealth;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        friendHealth.transform.localScale = new Vector3(CalculateHealth(currentHealth), friendHealth.transform.localScale.y, friendHealth.transform.localScale.z);
    }
    float CalculateHealth(float currenthealth)
    {
        return currenthealth / maxHealth;
    }
}
