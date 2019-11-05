using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Vector3 startingPos;
    public Transform trans;
    public float amountToMove;
    public float moveSpeed;

    void Start()
    {
        trans = GetComponent<Transform>();
        startingPos = trans.position;
    }
    void Update()
    {
        trans.position = new Vector3(startingPos.x + Mathf.PingPong(Time.time * moveSpeed, amountToMove), startingPos.y, startingPos.z);
    }
}


