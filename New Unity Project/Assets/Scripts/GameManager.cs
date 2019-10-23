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
    Collider2D col;
    MeshRenderer mesh;

    void Start()
    {
        hidden = GameObject.FindGameObjectsWithTag("Hidden");
        for (int i = 0; i < hidden.Length; i++)
        {
            col = hidden[i].GetComponent<Collider2D>();
            mesh = hidden[i].GetComponent<MeshRenderer>();
            col.enabled = true;
        }
        specialReady = true;
    }

    void Update()
    {
        if (specialActive == true)
        {
            for (int i = 0; i < hidden.Length; i++)
            {
                col = hidden[i].GetComponent<Collider2D>();
                mesh = hidden[i].GetComponent<MeshRenderer>();
                mesh.enabled = true;
                if (!persitentPlatform)
                {
                    col.enabled = true;                   
                }
            }
        }

        if (specialActive == false)
        {
            for (int i = 0; i < hidden.Length ; i++)
            {
                col = hidden[i].GetComponent<Collider2D>();
                mesh = hidden[i].GetComponent<MeshRenderer>();
                mesh.enabled = false;
                if (!persitentPlatform)
                {
                    col.enabled = false;                    
                }
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
            //Invoke("DeactivateSpecial", specialTime);
        }
    }

    public void DeactivateSpecial()
    {
        specialActive = false;
        specialReady = false;
        Invoke("CoolDown", cooldownTime);
    }

    void CoolDown()
    {
        specialReady = true;
    }
    //----------------------------------------------------------------
}