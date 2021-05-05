using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyStandart
{
    [Header("Enemy Movement")]
    public float enemyMoveSpeed = 1f;
    public float safetyDistance = 1f;
    public float retreatDistance = 1f;
    bool canMove = true;

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

        if (target && canMove)
        {
            if (transform.position.y > 4.5)
            {
                Vector2 newPosition = new Vector2(transform.position.x, 4.5f);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (transform.position.y < -4.5)
            {
                Vector2 newPosition = new Vector2(transform.position.x, -4.5f);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (transform.position.x > 8.5)
            {
                Vector2 newPosition = new Vector2(8.5f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

                if (canShoot)
                {
                    ShootProjectile();
                }
            }
            else if (transform.position.x < -8.5)
            {
                Vector2 newPosition = new Vector2(-8.5f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPosition, enemyMoveSpeed * Time.deltaTime);

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

    public bool CanEnemyMove()
    {
        return canMove;
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
        if (canMove)
        {
          //  AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
            GameObject newProjectile = Instantiate(enemyProjectilePrefab, projectileSpawner.transform.position, Quaternion.identity) as GameObject;
            cooldownTimer = cooldownDuration;
        }
    }
}
