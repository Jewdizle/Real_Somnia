using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private bool moving = false;
    private Animator anim;
    Controller2D controller;
    Player player;
    private bool isAwake = false;
    public GameObject parent;

    [HideInInspector]
    public bool doubleJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
        controller = GetComponentInParent<Controller2D>();
    }

    void Update()
    {
        //constantly sets moving to false to let the animator know to idle
        moving = false;

        //Begnis the game on pressing W, note that controls aren't locked at the moment
        if (Input.GetKey(KeyCode.W) && isAwake == false)
        {
            isAwake = true;
            anim.SetTrigger("anyButtonStart");
        }

        //Tests if the player is running right, set them to visually be running right, then plays the run animation
        if (Input.GetKey(KeyCode.D))
        {
            FaceRight();
        }

        //Same as above but for left
        if (Input.GetKey(KeyCode.A))
        {
            FaceLeft();
        }

        //Playing the idle or running animations
        if (moving == true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //Resets the double jump testing
        if (controller.collisions.below)
        {
            doubleJumped = false;
        }

        //Triggers the takeoff animation, and the mid jump
        if (controller.collisions.below && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("takeOff");
        }

        //Triggers the doubletakeoff animation, and mid doublejump
        if (doubleJumped == false && Input.GetKeyDown(KeyCode.Space) && !controller.collisions.below)
        {
            anim.SetTrigger("doubleTakeOff");
            doubleJumped = true;
        }
        
        //Tells the game to play the mid jumps until false, where it plays landing animation
        if (!controller.collisions.below)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }


        if (Input.GetKeyDown(KeyCode.LeftControl) && controller.collisions.below)
        {
            anim.SetTrigger("actionButton");
        }
    }

    void FaceRight()
    {
        parent.transform.eulerAngles = new Vector3(0, 0, 0);
        moving = true;
    }

    void FaceLeft()
    {
        parent.transform.eulerAngles = new Vector3(0, 180, 0);
        moving = true;
    }
}
