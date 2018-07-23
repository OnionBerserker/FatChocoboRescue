using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGuage : MonoBehaviour {

    private float currentHealth;
    public float maxHealth; 
    public GameObject healthBar;
    
    void Start()
    {
        maxHealth = PlayerController.character.GetComponent<PlayerController>().health;
    }

    void FixedUpdate()
    {
        currentHealth = PlayerController.character.GetComponent<PlayerController>().health;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthBar.transform.localScale = new Vector3(CalculateHealth(currentHealth), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
    float CalculateHealth(float currenthealth)
    {
        return currenthealth / maxHealth;
    }
}
