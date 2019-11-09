using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawnManager : MonoBehaviour
{

    public Transform respawnPoint;

    public GameObject wall;
    public GameObject platforms;
    public GameObject fallCollectable;
    public Animator fadeAnim;


    // Start is called before the first frame update
    void Start()
    {
       /* wall = GameObject.Find("Falling_Walls");
        platforms = GameObject.Find("Moving_Platforms");
        fallCollectable = GameObject.Find("FallCollectable");*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.transform.position = respawnPoint.transform.position;
        fadeAnim.SetTrigger("fadeToBlack");
        wall.SetActive(false);
        platforms.SetActive(true);
        fallCollectable.SetActive(true);
    }
}

