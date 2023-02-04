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

        // Animations
        animator.SetFloat("speed", Mathf.Abs(movement.x));
    }
}
