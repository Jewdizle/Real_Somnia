using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{

    
    public float speed;
    public Transform target;
    private Vector3 enemyPos = new Vector3(19.5f, 34f, 0);
    public int minDist;
    public int maxDist;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        

    }

    
    void Update()
    {
        float xPos = transform.position.x;
        enemyPos = new Vector3(Mathf.Clamp(xPos, 17, 45), 34f, 0f);
        transform.position = enemyPos;
        if (Vector2.Distance(enemyPos, target.position) <= minDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }

        else if (Vector2.Distance(enemyPos, target.position) >= maxDist)
        {
            transform.position = enemyPos;
        }

    


}
    
    /*public Transform Player;
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
     */
 }
