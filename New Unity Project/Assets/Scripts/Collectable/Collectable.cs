using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Renderer[] mat;
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
        for(int i = 0; i<dreamArea.Length-1; i++)
        {
            mat[i] = dreamArea[i].GetComponent<Renderer>();
        }
        Debug.Log(mat.Length);
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
            for (int i = 0; i < mat.Length - 1; i++)
            {
                mat[i].material = goodDreamMaterial;
            }
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
