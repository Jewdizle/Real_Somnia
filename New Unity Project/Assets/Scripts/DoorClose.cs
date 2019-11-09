using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public GameObject door;
    private Transform target;
    public float closeSpeed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("DoorTarget").GetComponent<Transform>();
        door.transform.position = new Vector3(50.7f, 49.74f, 1);
        target.transform.position = new Vector3(51f, 36.02f, 1);
    }

 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("locked");
            
            door.transform.position = Vector3.MoveTowards(door.transform.position, target.position, closeSpeed * Time.deltaTime);
            Destroy(gameObject);
        }
    }
}
