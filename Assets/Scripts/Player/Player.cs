using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer playerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerRenderer.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
