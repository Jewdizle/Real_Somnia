using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GameObject deathZone;
    public GameObject deathzone2;
    public GameObject wallsR;
    public GameObject wallsL;
    public GameObject platforms;
    public GameObject implosionEffect;
    public GameObject evilExplosion;
    public GameObject verticalOffsetTrigger;


    private void Start()
    {
        
        wallsR.SetActive(false);
        wallsL.SetActive(false);
    }

    public void Collect()
    {
        CameraFollow.verticalSmoothTime = 0.1f;
        Instantiate(implosionEffect);
        Instantiate(evilExplosion);
        //Instantiate(verticalOffsetTrigger);
        Player.gravity = -5f;
        Destroy(platforms);
        deathZone.SetActive(false);
        deathzone2.SetActive(false);
        wallsR.SetActive(true);
        wallsL.SetActive(true);
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {
                Collect();
            }
    }
}
