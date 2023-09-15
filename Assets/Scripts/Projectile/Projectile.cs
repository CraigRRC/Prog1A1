using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float firePower = 50f;
    public float projectileLifespan = 5f;
    private float timer = 0f;
    private void Update()
    {
        //Fire the projectile at the speed of firePower.
        transform.Translate(Vector3.up * firePower * Time.deltaTime);
        timer += Time.deltaTime;
        //Destroys the projectile after the timer has reached it's threshold.
        if (timer > projectileLifespan)
        {
            
            Destroy(gameObject);
        }
    }
}
