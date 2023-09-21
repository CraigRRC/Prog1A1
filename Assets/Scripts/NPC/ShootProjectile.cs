using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ShootProjectile : MonoBehaviour
{
    public Projectile projectilePrefab;
    public GameObject blaster;
    public float effectiveRange = 5f;
    public float timer = 0f;
    public float lockOnDuration = 2f;
    public bool targetAcquired = false;

    private PlayerRangeDetection rangeFinder;
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        //Grabbing references to our PlayerRangeDetection object and our SpriteRenderer object.
        rangeFinder = GetComponent<PlayerRangeDetection>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (IsChasingAndWithinEffectiveRange())
        {
            //The most sharp colour to show aggression.
            spriteRenderer.color = Color.red;
            timer += Time.deltaTime;
            //If the player stays in range for the duration of lockOnDuration, we fire.
            if (timer >= lockOnDuration)
            {
                Shoot(projectilePrefab);
                timer = 0f;
            }
        }
        else
        {
            //Otherwise, reset.
            timer = 0f;
        }
    }

    //Returns true if we are chasing and we are within the effective range
    private bool IsChasingAndWithinEffectiveRange()
    {
        return rangeFinder.GetIsChasing() && rangeFinder.GetDistanceToPlayer() <= effectiveRange;
    }

    //Function that takes a projectile by value, and then instantiates it at our blaster transform position, rotated to our rotation.
    public void Shoot(Projectile projectile)
    {
        Instantiate(projectile, blaster.transform.position, transform.rotation);
    }

}
