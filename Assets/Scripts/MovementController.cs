using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;

    public float speed;
    private Vector2 movement;

    // audio
    private PlayerSoundController soundController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundController = GetComponent<PlayerSoundController>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical).normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        UpdateAnimations();

 		// Audio
        soundController.PlayFootStepsIfMoving(movement);
    }

    // Animations
    private void UpdateAnimations() 
    {
        // Left and Right
        if (movement.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (movement.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Idling for up/down motion
        if (movement.x == 0) {
            animator.SetBool("is_idle", true);
        } else {
            animator.SetBool("is_idle", false);
        }

        // Running?
        animator.SetFloat("speed_x", Mathf.Abs(movement.x));
        animator.SetFloat("speed_y", movement.y);
    }
}
