using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipAnimation : MonoBehaviour
{
    private Player player;
    private Animations anims;
    private Animator spinner;
    Controller2D controller;
    private bool doubleJumped;
    private bool otherJumped;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        anims = GetComponentInChildren<Animations>();
        spinner = GetComponent<Animator>();
        controller = GetComponentInParent<Controller2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.collisions.below)
        {
            doubleJumped = false;
        }

        if (doubleJumped == false && Input.GetKeyDown(KeyCode.Space) && !controller.collisions.below)
        {
            spinner.SetTrigger("beginSpin");
            doubleJumped = true;
            otherJumped = true;
        }

        if (controller.collisions.below && otherJumped == true)
        {
            spinner.SetTrigger("hitGround");
            otherJumped = false;
        }

    }
}
