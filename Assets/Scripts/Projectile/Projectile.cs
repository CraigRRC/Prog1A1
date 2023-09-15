using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float firePower = 50f;
    private void Update()
    {
        transform.Translate(Vector3.up * firePower * Time.deltaTime);
    }
}
