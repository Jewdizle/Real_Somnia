using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private bool moving = false;
    private Animator anim;
    Controller2D controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponentInParent<Controller2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            moving = true;
        }


        if (Input.GetKey(KeyCode.A))
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

        if (controller.collisions.below && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("takeOff");
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
