using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shade : MonoBehaviour
{
    Material mat;

    GameManager gm;

    float alpha;
    int iterations = 100;

    public float rampUpTime = 1f;
    public float rampDownTime = 1f;

    [HideInInspector]
    public bool opaque;

    float ramp;

    void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
        alpha = 0;
        mat = gameObject.GetComponent<Material>();
        mat.SetFloat("_shaderAlpha", alpha);
        opaque = false;

    }

    private void Update()
    {
        if(opaque == true && alpha < 1f)
        {
            alpha = Mathf.Lerp(0f, 1f, ramp);
            mat.SetFloat("_shaderAlpha", alpha);
            ramp = ramp + 0.1f;
        }

        if (opaque == false && alpha > 0.0f)
        {
            Debug.Log("RampDown");
            alpha = Mathf.Lerp(0f, 1f, ramp);
            mat.SetFloat("_shaderAlpha", alpha);
            ramp = ramp - 0.1f;      
        }

        Debug.Log(alpha);
    }

    void RampUp()
    {
        opaque = true;       
    }

    public void RampDown()
    {
        opaque = false;        
    }

    public void ChangeMat()
    {
        if(opaque == true)
        {
            RampDown();           
        }
        if(opaque ==  false)
        {
            RampUp();
        }
    }
}