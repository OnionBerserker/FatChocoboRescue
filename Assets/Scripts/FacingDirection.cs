using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingDirection : MonoBehaviour {

    int facingDirection;

    private bool moveFoward;
    private bool moveLeft;
    private bool moveRight;
    private bool moveBack;
   
    void Start()
    {
        facingDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Direction===========================================
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
        {
            moveBack = false;
        }
        //===============================================================
    }

    public int GetDirection()
    {
        return facingDirection;
    }

    void FixedUpdate()
    {
        //Movement===============================================================================
        if (moveFoward)
        {
            if (facingDirection == 3)
            {
                transform.Rotate(0, 180, 0);
                facingDirection = 0;
            }
            if (facingDirection == 1)
            {
                transform.Rotate(0, 90, 0);
                facingDirection = 0;
            }
            if (facingDirection == 2)
            {
                transform.Rotate(0, 270, 0);
                facingDirection = 0;
            }
        }
        if (moveLeft)
        {
            if (facingDirection == 2)
            {
                transform.Rotate(0, 180, 0);
                facingDirection = 1;
            }
            if (facingDirection == 0)
            {
                transform.Rotate(0, 270, 0);
                facingDirection = 1;
            }
            if (facingDirection == 3)
            {
                transform.Rotate(0, 90, 0);
                facingDirection = 1;
            }
        }
        if (moveRight)
        {

            if (facingDirection == 1)
            {
                transform.Rotate(0, 180, 0);
                facingDirection = 2;
            }
            if (facingDirection == 0)
            {
                transform.Rotate(0, 90, 0);
                facingDirection = 2;
            }
            if (facingDirection == 3)
            {
                transform.Rotate(0, 270, 0);
                facingDirection = 2;
            }
        }
        if (moveBack)
        {
            if (facingDirection == 0)
            {
                transform.Rotate(0, 180, 0);
                facingDirection = 3;
            }
            if (facingDirection == 1)
            {
                transform.Rotate(0, 270, 0);
                facingDirection = 3;
            }
            if (facingDirection == 2)
            {
                transform.Rotate(0, 90, 0);
                facingDirection = 3;
            }
        }
        //=======================================================================================
    }

}
