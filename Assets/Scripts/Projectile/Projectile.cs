using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float firePower = 50f;
    public float destroyTimer = 0f;
    private void Update()
    {
        transform.Translate(Vector3.up * firePower * Time.deltaTime);
        destroyTimer += Time.deltaTime;
        if ( destroyTimer > 5f)
        {
            Destroy(gameObject);
        }
    }
}
