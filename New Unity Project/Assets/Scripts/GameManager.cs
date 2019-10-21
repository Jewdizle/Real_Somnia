using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool specialReady;
    [HideInInspector]
    public bool specialActive;

    public float specialTime;
    public float cooldownTime;

    public GameObject[] hidden;
    Collider2D collider2D;
    MeshRenderer mesh;


    void Start()
    {
        hidden = GameObject.FindGameObjectsWithTag("Hidden");
        for (int i = 0; i < hidden.Length - 1; i++)
        {
            collider2D = hidden[i].GetComponent<Collider2D>();
            mesh = hidden[i].GetComponent<MeshRenderer>();
        }
        specialReady = true;
        Debug.Log(hidden.Length);
    }

    void Update()
    {
        if (specialActive == true)
        {
            for(int i = 0; i < hidden.Length-1; i++)
            {
                collider2D.enabled = true;
                mesh.enabled = true;
            }
        }

        if (specialActive == false)
        {
            for (int i = 0; i < hidden.Length - 1; i++)
            {
                collider2D.enabled = false;
                mesh.enabled = false;
            }
        }
    }

    //Special --------------------------------------------------------
    public void Special()
    {
        if (specialReady)
        {
            Debug.Log("Special Active");
            specialActive = true;
            specialReady = false;
            Invoke("DeactivateSpecial", specialTime);
        }
    }

    void DeactivateSpecial()
    {
        specialActive = false;
        Invoke("CoolDown", cooldownTime);
    }

    void CoolDown()
    {
        specialReady = true;
    }
    //----------------------------------------------------------------
}
