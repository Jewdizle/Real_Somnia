using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int collectedCollectables;
    public int totalCollectables;

    GameObject[] collectables;
    // Start is called before the first frame update
    void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
        totalCollectables = collectables.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            collectedCollectables++;
        }
    }
}
