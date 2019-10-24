using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool specialReady;
    [HideInInspector]
    public bool specialActive;

    public bool persitentPlatform;
    public bool deactivateOnMove;

    public float specialTime;
    public float cooldownTime;

    GameObject[] hidden;
    Sha shade;
    Collider2D col;
    //MeshRenderer mesh;

    void Start()
    {
        hidden = GameObject.FindGameObjectsWithTag("Hidden");
        specialReady = true;
    }

    void Update()
    {
        if (specialActive == true)
        {
            for(int i = 0; i<hidden.Length;i++)
            {
                shade = hidden[i].GetComponent<Sha>();
                shade.RampUp();
            }
        }

        if (specialActive == false)
        {
            for (int i = 0; i < hidden.Length -1; i++)
            {
                shade = hidden[i].GetComponent<Sha>();
                shade.RampDown();
            }

        }
           
    }

    //Special --------------------------------------------------------
    public void Special()
    {
        if (specialReady)
        {
            specialActive = true;
            specialReady = false;
            Invoke("DeactivateSpecial", specialTime);
        }
    }

    public void DeactivateSpecial()
    {
        if (specialActive)
        {
            specialActive = false;
            specialReady = false;
            Invoke("CoolDown", cooldownTime);
        }
    }

    void CoolDown()
    {
        specialReady = true;
    }
    //----------------------------------------------------------------
}