using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOffsetTrigger : MonoBehaviour

{
    
    

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CameraFollow.verticalSmoothTime = 0;
        }
    }
}
