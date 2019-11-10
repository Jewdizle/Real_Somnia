using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubZonePlatforms : MonoBehaviour
{
    public GameObject platform1;
    public GameObject platform2;
    bool visible;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (visible == false)
        {
            platform1.SetActive(true);
            visible = true;
        }
        else
        {
            platform2.SetActive(true);
        }


    }
}
