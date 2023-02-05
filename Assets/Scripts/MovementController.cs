using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;

    // audio
    private PlayerSoundController soundController;

    // Animations
    private AnimationController animationController;
    private string direction = "down";
    private StatsController stats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundController = GetComponent<PlayerSoundController>();
        animationController = GetComponent<AnimationController>();
        stats = FindObjectOfType<StatsController>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical).normalized * stats.speed / 2;
        rb.velocity = movement;

        // Animation
        animationController.MovementAnimation(movement);
        if (horizontal > 0) {
            direction = "right";
        } else if (horizontal < 0) {
            direction = "left";
        } else if (vertical > 0) {
            direction = "up";
        } else if (vertical < 0) {
            direction = "down";
        }

 		// Audio
        soundController.PlayFootStepsIfMoving(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    public string GetDirection() 
    {
        return direction;
    }
}
