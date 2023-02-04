using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;

    public float speed;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical).normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        UpdateAnimations();
    }

    private void UpdateAnimations() 
    {
        // Animations
        if (movement.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (movement.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (movement.x == 0) {
            animator.SetBool("is_idle", true);
        } else {
            animator.SetBool("is_idle", false);
        }
        animator.SetFloat("speed_x", Mathf.Abs(movement.x));
        animator.SetFloat("speed_y", movement.y);

    }
}
