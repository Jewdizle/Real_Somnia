using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlatform : MonoBehaviour
{
    Material mat;
    Color colour;
    Shader shader;
    int alpha;

    GameManager gm;
    public GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        gm = game.GetComponent<GameManager>();
        shader = GetComponent<Shader>();
        Debug.Log(colour);
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.specialActive)
        {
        }
    }
}
