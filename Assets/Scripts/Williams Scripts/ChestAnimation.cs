using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    public bool isPlayerInRange = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

            if (isPlayerInRange == true)
            {
                // Spiele Angriffsanimation ab
                animator.SetBool("isChest_Open", true);
            }
            else
            {
                animator.SetBool("isChest_Open", false);
                //animator.SetBool("isChesst_Idle", false);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
}
