using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sha : MonoBehaviour
{
    public Material mat;
    Collider2D col;

    GameManager gm;
    public GameObject game;

    float alpha;
    int iterations = 100;

    public float rampUpTime = 0.5f;
    public float rampDownTime = 0.5f;

    void Start()
    {
        gm = game.GetComponent<GameManager>();
        col = GetComponent<Collider2D>();
        alpha = 0;
        mat.SetFloat("_shaderAlpha", alpha);
    }

    public void RampUp()
    {
        if (!gm.persitentPlatform)
        {
            col.enabled = true;
        }

        /*for (int i = 0; i < iterations; i++)
        {
            alpha = i/iterations;
            mat.SetFloat("_shaderAlpha", alpha);
            yield return new WaitForSeconds(rampUpTime/iterations);
        }*/
    }

    public void RampDown()
    {
        if (!gm.persitentPlatform)
        {
            col.enabled = false;
        }



        /*for (int i = iterations; i > 0; i--)
        {
            alpha = i / iterations;
            mat.SetFloat("_shaderAlpha", alpha);
            yield return new WaitForSeconds(rampUpTime / iterations);
        }*/
    }
}
