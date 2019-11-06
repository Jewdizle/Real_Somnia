using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
 
    public Transform Player;
    public float MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;
    private Vector3 velocity;

     void Update()
     {
         transform.LookAt(Player);

        if (transform.position.x > Player.position.x)
        {
            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {
                velocity = new Vector3(MoveSpeed, 0, 0);
                transform.Translate(velocity);
            }
        }

        if (transform.position.x < Player.position.x)
        {
            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {
                velocity = new Vector3(-MoveSpeed, 0, 0);
                transform.Translate(velocity);
            }
        }
     }
 }
