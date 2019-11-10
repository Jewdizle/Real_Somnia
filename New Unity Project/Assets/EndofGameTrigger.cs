using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofGameTrigger : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.gravity = 20;
            CameraFollow.verticalSmoothTime = 0.1f;
            anim.SetTrigger("fadeToWhite");
            Invoke("LoadScene", 3); 
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Level0");
    }
}
