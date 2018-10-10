using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;
    private bool isGrounded;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
        //Animations

        //Player Direction
        if (moveX < 0.0 && facingRight == true)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0 && facingRight == false)
        {
            FlipPlayer();
        }

        //Physics
        float XVelocity = moveX * playerSpeed;
        float YVelocity = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XVelocity, YVelocity);
    }

    void Jump()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
            isGrounded = false;
        }
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
