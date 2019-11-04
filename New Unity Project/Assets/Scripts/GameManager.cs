using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool specialReady;
    bool specialActived;
    bool specialActive;

    public bool deactivateOnMove;

    public float specialTime;
    public float cooldownTime;
    public float rampTime = 1;

    [HideInInspector]
    public float alpha;

    public List<Renderer> hidden;

    void Start()
    { 
        alpha = 0f;
        for (int i = 0; i < hidden.Count-1; i++)
        {
            hidden[i].sharedMaterial.SetFloat("_shaderAlpha", alpha);
        }

        specialReady = true;
        specialActived = false;
        specialActive = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Special();
        }

        if(specialActive && alpha < 1f)
        {
            for (int i = 0; i < hidden.Count; i++)
            {
                if (hidden[i].sharedMaterial.GetFloat("_shaderAlpha") < 1f)
                {
                    alpha = alpha + Time.deltaTime * rampTime;
                    hidden[i].sharedMaterial.SetFloat("_shaderAlpha", alpha);
                }
            }
        }

        if(!specialActive && alpha > 0f)
        {

            for (int i = 0; i < hidden.Count; i++)
            {
                if (hidden[i].sharedMaterial.GetFloat("_shaderAlpha") > 0f)
                {
                    alpha = alpha - Time.deltaTime * rampTime;
                    hidden[i].sharedMaterial.SetFloat("_shaderAlpha", alpha);
                }
            }
        }


    }

    //Special --------------------------------------------------------
    public void Special()
    {
        if (specialReady == true)
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
            specialReady = false;
            specialActive = false;
            
            Invoke("CoolDown", cooldownTime);

        }
    }

    void CoolDown()
    {
        specialReady = true;
    }
    //----------------------------------------------------------------
}