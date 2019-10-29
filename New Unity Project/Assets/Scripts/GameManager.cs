using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool specialReady;
    [HideInInspector]
    public bool specialActived;
    [HideInInspector]
    public bool specialActive = false;
    public bool deactivateOnMove;

    public float specialTime;
    public float cooldownTime;

    Shade shade;
    Collider2D col;
    //MeshRenderer mesh;

    void Start()
    {       
        specialReady = true;      
        shade = gameObject.GetComponent<Shade>();
        
    }

    //Special --------------------------------------------------------
    public void Special()
    {
        if (specialReady == true)
        {
            specialActive = true;
            specialReady = false;            
            Invoke("DeactivateSpecial", specialTime);
            
                shade.ChangeMat();
           
 
        }
    }

    public void DeactivateSpecial()
    {
        if (specialActive)
        {
            specialReady = false;
            specialActive = false;
            
            shade.ChangeMat();
            
            Invoke("CoolDown", cooldownTime);

        }
    }

    void CoolDown()
    {
        specialReady = true;
    }
    //----------------------------------------------------------------
}