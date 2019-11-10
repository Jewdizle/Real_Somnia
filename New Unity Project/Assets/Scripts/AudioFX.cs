using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    AudioSource jumpSound;

    private void Start()
    {
        jumpSound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpSound.Play();
        }
    }
}
