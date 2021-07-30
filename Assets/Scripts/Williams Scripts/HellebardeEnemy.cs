using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellebardeEnemy : EnemyStandart
{
    public Animator animator;

    [Header("Enemy melee attack")]
    //public float chaseRadius;
    //public float attackRadius;
    private bool isPlayerInRange;

    private float attackDistance = 0.6f;
    private float retreatDistance = 0.8f;

    public BoxCollider2D box1;
    public BoxCollider2D box2;

    void Update()
    {
        if (isEnemyDeath == false)
        {
            CheckDistance();

            ControllEnemyMovementAndAttacking();
        }
        else
        {
            box1.enabled = false;
            box2.enabled = false;
            rb = null;
        }
    }

    /*
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius -0.7456)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // attackRadius);
            // animator.SetBool("isWalking", true);
        }
    }
}
    */
    void CheckDistance()
    {
        if (Vector2.Distance(target.position, transform.position) <= retreatDistance && Vector2.Distance(target.position, transform.position) > attackDistance)
        {
            isPlayerInRange = true;
        }
    }

    private void ControllEnemyMovementAndAttacking()
    {

        if (target)
        {
            //bewegen auf den Spieler
            if (Vector2.Distance(target.position, transform.position) > retreatDistance && Vector2.Distance(target.position, transform.position) > attackDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
            // ???
            else if (Vector2.Distance(transform.position, target.position) == attackDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.deltaTime);
                // transform.position = Vector2.MoveTowards(transform.position, target.position, rangeEnemySpeed * Time.deltaTime); // Zittern
            }

            else if (Vector2.Distance(transform.position, target.position) < attackDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            // wegbewegen vom Spieler
            else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.deltaTime);
            }
        }
    }
}