using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ShootProjectile : MonoBehaviour
{
    public Projectile projectilePrefab;
    public GameObject blaster;
    private PlayerRangeDetection rangeFinder;
    private SpriteRenderer spriteRenderer;
    public float effectiveRange = 5f;
    public float timer = 0f;
    public float lockOnDuration = 2f;
    public bool targetAcquired = false;

    public void Awake()
    {
        rangeFinder = GetComponent<PlayerRangeDetection>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (rangeFinder.chasePlayer && rangeFinder.GetDistanceToPlayer() <= effectiveRange)
        {
            spriteRenderer.color = Color.red;
            timer += Time.deltaTime;
            if (timer >= lockOnDuration)
            {
                Shoot(projectilePrefab);
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }
    public void Shoot(Projectile projectile)
    {
        Instantiate(projectile, blaster.transform.position, transform.rotation);
        Debug.Log(blaster.transform.position);
    }

}
