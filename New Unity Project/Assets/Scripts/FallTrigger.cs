using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GameObject deathZone;
    public GameObject walls;
    public GameObject platforms;


    private void Start()
    {
        walls.SetActive(false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            {
                Player.gravity = -5f;
                Destroy(platforms);
                deathZone.SetActive(false);
                walls.SetActive(true);
            }
        }
    }
}
