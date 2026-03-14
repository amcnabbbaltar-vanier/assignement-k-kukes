using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement movementScript;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float plrSpeed = movementScript.speed;
        animator.SetFloat("Speed", plrSpeed);

        if (rb.velocity.x == 0) {
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetButtonDown("Jump") && !movementScript.isOnGround && movementScript.hasDoubleJump)
        {
            animator.SetTrigger("Flip");
        }

        if (rb.velocity.y < -1f && !movementScript.isOnGround)
        {
            animator.SetBool("IsFalling", true);
        } else {
            animator.SetBool("IsFalling", false);
        }
    }
}
