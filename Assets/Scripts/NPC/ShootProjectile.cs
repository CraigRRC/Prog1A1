using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ShootProjectile : MonoBehaviour
{
    public Projectile projectilePrefab;
    public GameObject blaster;
    private PlayerRangeDetection rangeFinder;
    public float effectiveRange = 5f;
    public float timer = 0f;
    public bool targetAcquired = false;

    public void Awake()
    {
        rangeFinder = GetComponent<PlayerRangeDetection>();
    }

    public void Update()
    {
       

        if (rangeFinder.chasePlayer && rangeFinder.GetDistanceToPlayer() <= effectiveRange)
        {
            timer += Time.deltaTime;
            if (timer >= 5.0f)
            {
                Shoot(projectilePrefab);
                timer = 0f;
            }
            
        }
    }
    public void Shoot(Projectile projectile)
    {
        Instantiate(projectile, blaster.transform.position, transform.rotation);
        Debug.Log(blaster.transform.position);
    }

}