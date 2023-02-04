using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    private Vector2 movement;
    private int health = 10;
    private int damage = 2;


    // audio
    private PlayerSoundController soundController;

    // Animations
    private AnimationController animationController;

    // on hit :
    // animation
    // lower health
    // hit sound
    // check for death
    // if dead then animation / sound

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundController = GetComponent<PlayerSoundController>();
        animationController = GetComponent<AnimationController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            decreaseHealth(2);
        }
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

    public void decreaseHealth(int damageDelt)
    {
        health -= damageDelt;

        if (health <= 0)
        {
            soundController.playDeathScream();
            animationController.DeathAnimation();
            Destroy(gameObject, 1);

            return;
        }

        soundController.playOnHit();
        animationController.HitAnimation();
    }
}
