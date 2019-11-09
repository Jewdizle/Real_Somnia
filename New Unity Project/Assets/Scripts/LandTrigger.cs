﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraFollow.verticalSmoothTime = 0.2f;
            Player.gravity = -50f;
        }
    }
}