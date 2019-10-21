using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 6f;

    public float jumpHeight = 4;
    public float timeToJumpApex = 1;
    float gravity;
    float jumpVelocity;
    bool doubleJumped;

    Vector3 velocity;
    Controller2D controller;
    GameManager gm;
    public GameObject game;

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
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetButtonDown("Jump"))
        {
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

        if(Input.GetButtonDown("Fire1"))
        {
            gm.Special();
        }
    }
}
