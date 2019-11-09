using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Renderer mat;
    GameObject[] dreamArea;
    public GameObject particles;
    public Material goodDreamMaterial;
    public int area;
    string dreamMat = "DreamArea";
    bool nearCollectable;
    bool interacted;

    private void Start()
    {
        dreamArea = GameObject.FindGameObjectsWithTag("DreamArea" + area);
    }

    private void Update()
    {
        if (nearCollectable == true && Input.GetButtonDown("Fire1") && interacted == false)
        {
            Collect();
        }
    }
   
    void Collect()
    {
        
        Instantiate(particles, gameObject.transform);
        for (int i = 0; i < dreamArea.Length; i++)
        {
            mat = dreamArea[i].GetComponent<Renderer>(); 
            mat.material = goodDreamMaterial;
        }
        interacted = true;
        
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
