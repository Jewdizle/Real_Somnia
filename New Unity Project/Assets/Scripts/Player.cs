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
    bool specialReady;
    bool specialActive;
    public float specialTime;

    Vector3 velocity;
    Controller2D controller;

    private void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        specialReady = true;
        specialActive = false;
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
            Special();
        }
    }

    void Special()
    {
        if(specialReady)
        {
            Debug.Log("Special Active");
            specialActive = true;
            specialReady = false;
            Invoke("DeactivateSpecial", specialTime);
        }
    }

    void DeactivateSpecial()
    {
        specialActive = false;
    }

    void CoolDown()
    {

    }
}
