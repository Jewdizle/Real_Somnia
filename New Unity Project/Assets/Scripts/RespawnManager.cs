using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Animator fadeAnim;
    public Transform respawnPoint;
    public GameObject player;
    bool respawned;



    // Start is called before the first frame update
    void Start()
    {
       player.GetComponent<PlayerInput>();
       player.GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (respawned == true)
        {
            Invoke("EnableMove", 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.transform.position = respawnPoint.transform.position;
        fadeAnim.SetTrigger("fadeToBlack");
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<Player>().enabled = false;
        
        respawned = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        respawned = false;

    }

    void EnableMove()
    {
        player.GetComponent<PlayerInput>().enabled = true;
        player.GetComponent<Player>().enabled = true;
    }
}


