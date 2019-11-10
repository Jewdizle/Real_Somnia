using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GameObject deathZone;
    public GameObject deathzone2;
    public GameObject walls;
    public GameObject platforms;
    public GameObject implosionEffect;
    public GameObject evilExplosion;
    public GameObject gravityTrigger;
    public Animator anim;


    private void Start()
    {
        walls.SetActive(false);

    }

    public void Collect()
    {
        
        anim.SetTrigger("falling");
        Player.gravity = -10;
        Instantiate(implosionEffect);
        Instantiate(evilExplosion);
        platforms.SetActive(false);
        deathZone.SetActive(false);
        deathzone2.SetActive(false);
        gravityTrigger.SetActive(true);
        walls.SetActive(true);
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {
                Collect();
            }
    }
}
