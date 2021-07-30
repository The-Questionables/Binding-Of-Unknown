using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Combination : MonoBehaviour
{
    public KeyCode Attack = KeyCode.Mouse0;
    public Animator animator;
    private bool attack = false;


    private void Update()
    {
        
        if (Input.GetKeyDown(Attack))
        {
            if (attack == false)
            {
                animator.SetTrigger("Attack");
                attack = true;
            }
        }
        if (animator.GetBool("Attack") == false)
        {
            Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (attack == true)
        {
            attack = false;
        }
    }
}
