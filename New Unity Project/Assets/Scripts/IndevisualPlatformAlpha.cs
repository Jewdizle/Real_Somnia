using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndevisualPlatformAlpha : MonoBehaviour
{
    Renderer render;
    float localAlpha;
    GameManager gm;

    bool rampUp;
    bool rampDown;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
        render = gameObject.GetComponentInParent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        localAlpha = gm.alpha;

        if (localAlpha < 1f)
        {
            rampUp = true;
        }
    }
    private void Update()
    {
        if (rampUp)
        {
            if (localAlpha < 1f)
            {
                localAlpha = localAlpha + Time.deltaTime * gm.rampTime;
                render.sharedMaterial.SetFloat("_shaderAlpha", localAlpha);
                rampUp = false;
            }
        }    

        if(rampDown)
        {
            if (localAlpha > 0f)
            {
                localAlpha = localAlpha - Time.deltaTime * gm.rampTime;
                render.sharedMaterial.SetFloat("_shaderAlpha", localAlpha);
                rampDown = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");
        rampDown = true;
    }
}
