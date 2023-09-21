using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private SpriteRenderer npcSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        npcSpriteRenderer = GetComponent<SpriteRenderer>();
        npcSpriteRenderer.color = Color.blue;
    }
}
