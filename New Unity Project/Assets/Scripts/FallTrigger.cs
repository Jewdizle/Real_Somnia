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

    public void Collect()
    {
        Player.gravity = -5f;
        Destroy(platforms);
        deathZone.SetActive(false);
        walls.SetActive(true);
        Destroy(gameObject);
    }
}
