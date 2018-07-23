using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashGuage : MonoBehaviour {

    private float currentDash;
    private float maxDash;
    public GameObject dashGuage;

	void Start ()
    {
        maxDash = PlayerController.character.GetComponent<PlayerController>().dashMeter;
        currentDash = maxDash;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentDash = PlayerController.character.GetComponent<PlayerController>().dashMeter;
        if (currentDash < 0)
        {
            currentDash = 0;
        }
        dashGuage.transform.localScale = new Vector3(CalculateDash(currentDash), dashGuage.transform.localScale.y, dashGuage.transform.localScale.z);
    }
    float CalculateDash(float currentdash)
    {
        return currentdash / maxDash;
    }
}
