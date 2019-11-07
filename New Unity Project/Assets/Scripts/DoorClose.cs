using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public GameObject door;
    public Transform target;
    public float closeSpeed;
    
    void Start()
    {
        door.transform.position = new Vector3(48.63f, 54.83f, 1);
        target.transform.position = new Vector3(48.63f, 46, 1);
    }

 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("locked");
            float step = closeSpeed * Time.deltaTime; // calculate distance to move
            door.transform.position = Vector3.MoveTowards(target.position, door.transform.position, step);
            Destroy(this);
        }
    }
}
