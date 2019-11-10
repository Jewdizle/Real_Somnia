using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2Visible : MonoBehaviour
{
    public GameObject platform2;
    bool nearCollectable;


    // Update is called once per frame
    void Update()
    {
        if (nearCollectable == true && Input.GetButtonDown("Fire1"))
        {
            Visible();
        }
    }

    void Visible()
    {
        platform2.SetActive(true);
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
