﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 6f;

    public float jumpHeight = 4;
    public float timeToJumpApex = 1;
    public float gravityMultiplyer = 1;
    float gravity;
    float jumpVelocity;
    bool doubleJumped;

    Vector3 velocity;
    Controller2D controller;
    GameManager gm;
    public GameObject game;
    bool nearIneractable;

    public bool isMoving;
    public bool isJumping;
    public bool facingRight;

    private void Start()
    {
        controller = GetComponent<Controller2D>();
        gm = game.GetComponent<GameManager>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    private void Update()
    {
        if(controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        if(controller.collisions.below)
        {
            isJumping = false;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            if (controller.collisions.below == true)
            {
                velocity.y = jumpVelocity;
                doubleJumped = false;               
            }
            if (controller.collisions.below == false && doubleJumped == false)
            {
                velocity.y = jumpVelocity;
                doubleJumped = true;
            }
        }
        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (gm.deactivateOnMove && gm.specialActive)
        {
            if (input.x != 0 || input.y != 0 || Input.GetButtonDown("Jump"))
            {
                gm.DeactivateSpecial();
            }
        }

        if (input.x != 0)
        {
            isMoving = true;
            if(input.x>0)
            {
                facingRight = true;
            }
            if (input.x<0)
            {
                facingRight = false;
            }
        }

        if( input.x == 0)
        {

        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (!nearIneractable)
            {
                gm.Special();
            }           
        }
    }
}