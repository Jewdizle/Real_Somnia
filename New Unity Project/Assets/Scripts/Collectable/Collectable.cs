using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Renderer mat;
    GameObject[] dreamArea;
    public GameObject enemies;
    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public Material goodDreamMaterial;
    public Animator fadeAnim;
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
        Instantiate(particle1, gameObject.transform);
        Instantiate(particle2, gameObject.transform);
        fadeAnim.SetTrigger("fadeToBlack");
        Destroy(enemies, 1f);
        particle3.SetActive(true);


     
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
