using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    private Vector2 movement;

    // audio
    private PlayerSoundController soundController;

    // Animations
    private AnimationController animationController;

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
        movement = new Vector2(horizontal, vertical).normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Animation
        animationController.MovementAnimation(movement);

 		// Audio
        soundController.PlayFootStepsIfMoving(movement);
    }

}
