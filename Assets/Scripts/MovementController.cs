using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    private Vector2 movement;

    // audio
    private PlayerSoundController soundController;

    // Animations
    private AnimationController animationController;
    private string direction = "down";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundController = GetComponent<PlayerSoundController>();
        animationController = GetComponent<AnimationController>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical).normalized * speed;
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

    public string GetDirection() 
    {
        return direction;
    }
}
