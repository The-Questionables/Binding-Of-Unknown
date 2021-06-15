using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellebardeEnemy : EnemyStandart
{
    public Animator animator;

    [Header("Enemy melee attack")]
    public float chaseRadius;
    public float attackRadius;


    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius -0.7456)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // attackRadius);
            // animator.SetBool("isWalking", true);
        }
    }
}

// animator.SetFloat("Horizontal", movement.x);
// animator.SetFloat("Vertical", movement.y);
// animator.SetFloat("Speed", movement.sqrMagnitude);