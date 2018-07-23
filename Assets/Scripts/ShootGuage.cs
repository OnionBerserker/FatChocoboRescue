using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGuage : MonoBehaviour {

    private float maxAmmo;
    private float currentAmmo;
    public GameObject shootGuage;
    
    // Use this for initialization
	void Start ()
    {
        maxAmmo = Shoot.character.GetComponent<Shoot>().ammo;
        currentAmmo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentAmmo = Shoot.character.GetComponent<Shoot>().ammo;
        if (currentAmmo < 0 )
        {
            currentAmmo = 0;
        }
        shootGuage.transform.localScale = new Vector3(CalculateAmmo(currentAmmo), shootGuage.transform.localScale.y, shootGuage.transform.localScale.z);

    }
    float CalculateAmmo(float currentammo)
    {
        return currentammo / maxAmmo;
    }
}
