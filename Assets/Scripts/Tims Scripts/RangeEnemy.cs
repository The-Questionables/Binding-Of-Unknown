using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyStandart
{
    [Header("Enemy Movement")]
    public float enemyMoveSpeed = 1f;
    public float safetyDistance = 1f;
    public float retreatDistance = 1f;

    [Header("Enemy Projectile")]
    public GameObject projectileSpawner;
    public float cooldownTimer = 1f;
    private bool canShoot = true;
    public GameObject enemyProjectilePrefab;
    float cooldownDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        ControllEnemyMovementAndShooting();

        HandleShootingCooldownTime();
    }

    private void ControllEnemyMovementAndShooting()
    {

        if (target)
        {

            if (Vector3.Distance(target.position, transform.position) > retreatDistance && Vector3.Distance(target.position, transform.position) > safetyDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // attackRadius);
                if (canShoot)
                {
                    ShootProjectile();
                }
            }

            else if (Vector2.Distance(transform.position, target.position) > safetyDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemyMoveSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < safetyDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
            {
                transform.position = this.transform.position;

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -enemyMoveSpeed * Time.deltaTime);

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
       
          //  AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
            GameObject newProjectile = Instantiate(enemyProjectilePrefab, projectileSpawner.transform.position, Quaternion.identity) as GameObject;
            cooldownTimer = cooldownDuration;
        
    }
}
