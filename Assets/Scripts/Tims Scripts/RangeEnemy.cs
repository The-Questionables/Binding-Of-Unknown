using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyStandart
{
    public Animator animator;

    [Header("Enemy Movement")]
    public float rangeEnemySpeed = 1f;
    public float safetyDistance = 1f;
    public float retreatDistance = 1f;
    bool isPlayerInRange = false;

    [Header("Enemy Projectile")]
    public GameObject projectileSpawner;
    public float cooldownTimer = 1f;
    private bool canShoot = false;
    public GameObject enemyProjectilePrefab;
    float cooldownDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        CheckDistance();

        ControllEnemyMovementAndShooting();

        HandleShootingCooldownTime();

        if (isEnemyDeath == true)
        {
            rangeEnemySpeed = 0;
        }
    }

    void CheckDistance()
    {
        if (Vector2.Distance(target.position, transform.position) <= retreatDistance && Vector2.Distance(target.position, transform.position) > safetyDistance)
        {
            isPlayerInRange = true;
        }
    }


    private void ControllEnemyMovementAndShooting()
    {

        if (target)
        {
            //bewegen auf den Spieler
            if (Vector2.Distance(target.position, transform.position) > retreatDistance && Vector2.Distance(target.position, transform.position) > safetyDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, rangeEnemySpeed * Time.deltaTime); 
                if (canShoot)
                {

                }
                
            }
            // ???
            else if (Vector2.Distance(transform.position, target.position) > safetyDistance)
            {
                if (canShoot)
                {
                    ShootProjectile();
                }
                // transform.position = Vector2.MoveTowards(transform.position, target.position, rangeEnemySpeed * Time.deltaTime); // Zittern
            }

            else if (Vector2.Distance(transform.position, target.position) < safetyDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
            {
                transform.position = this.transform.position;

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            // wegbewegen vom Spieler
            else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -rangeEnemySpeed * Time.deltaTime);
                if (canShoot)
                {
                    ShootProjectile();
                }
            }
        }
    }

    private void HandleShootingCooldownTime()
    {
        if (cooldownTimer <= 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void ShootProjectile()
    {
       if (isPlayerInRange)
       {
           // rb.isKinematic = false;
          //  AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
            GameObject newProjectile = Instantiate(enemyProjectilePrefab, projectileSpawner.transform.position, Quaternion.identity) as GameObject;
            cooldownTimer = cooldownDuration;
       }
    }
}
