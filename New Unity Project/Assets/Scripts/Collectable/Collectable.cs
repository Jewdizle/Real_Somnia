using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{


    public Material nightmareMAT;
    public Material dreamMAT;

    //Make tag "DreamArea0" and match the area int to the number at the end
    public int area = 0;

    //cystals you want to change material
    public GameObject[] affectedCrystals;

    //instantiated particles on interact
    public GameObject particles;
    
    string dreamMat = "DreamArea";
    bool nearCollectable;
    bool interacted;

    private void Start()
    {
        affectedCrystals = GameObject.FindGameObjectsWithTag("DreamArea" + area);
        for(int i = 0;i <affectedCrystals.Length-1; i++)
        {
            Renderer renderer = affectedCrystals[i].GetComponent<Renderer>();
            renderer.material = nightmareMAT;
        }
    }

    private void Update()
    {
        if (nearCollectable && Input.GetButton("Fire1"))
        {
            Collect();
        }
    }
   
    void Collect()
    {
        if (!interacted)
        {
            Instantiate(particles, gameObject.transform);
            for (int i = 0; i < affectedCrystals.Length; i++)
            {
                Renderer renderer = affectedCrystals[i].GetComponent<Renderer>();
                renderer.material = dreamMAT;
            }
            interacted = true;            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nearCollectable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearCollectable = false;
    }
}
