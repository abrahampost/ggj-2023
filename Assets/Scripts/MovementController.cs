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
    private SpriteRenderer spriteRenderer;
    private Color originColor;

    // Health
    private float health = 100;
    private StatsController stats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundController = GetComponent<PlayerSoundController>();
        animationController = GetComponent<AnimationController>();

        spriteRenderer = GetComponentsInChildren<SpriteRenderer>()[0];
        originColor = spriteRenderer.color;

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

    public float GetHealth() 
    {
        return health;
    }

    // Modify Stats
    public void TakeDamage(float value)
    {
        ModifyHealthByValue(-value);
    }

    public void Heal(float value)
    {
        ModifyHealthByValue(value);
    }

    public void ModifyHealthByValue(float value)
    {
        health += value;

        // Color on hit
        if (value < 0) {
        }

        if (health <= 0)
        {
            // agent.speed = 0;
            soundController.playDeathScream();
            animationController.DeathAnimation();
            // Destroy(gameObject, 1.0f);

            return;
        }

        soundController.playOnHit();
        animationController.HitAnimation();
    }

    private void SetColor(Color color) {
        spriteRenderer.color = color;
    }

    public void Blink() 
    {
        SetColor(new Color(100, 0, 0));

        StartCoroutine(ResetColor());
        IEnumerator ResetColor()
        {
            yield return new WaitForSecondsRealtime(0.2f);
            SetColor(originColor);
        }
    }
}
