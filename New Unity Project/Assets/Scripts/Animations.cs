using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private bool moving = false;
    private Animator anim;
    Controller2D controller;
    Player player;

    [HideInInspector]
    public bool doubleJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
        controller = GetComponentInParent<Controller2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            moving = true;
        }


        if (Input.GetAxis("Horizontal") < 0f)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            moving = true;
        }

        if (moving == true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (controller.collisions.below)
        {
            doubleJumped = false;
        }

        if (controller.collisions.below && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("takeOff");
        }

        if (doubleJumped == false && Input.GetButtonDown("Jump") && !controller.collisions.below)
        {
            anim.SetTrigger("doubleTakeOff");
            doubleJumped = true;
        }
        

        if (!controller.collisions.below)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }


        //The player is grounded
        //The player hits the jump key
    }
}
