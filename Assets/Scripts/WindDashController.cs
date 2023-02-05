using System;
using System.Collections.Generic;
using UnityEngine;

public class WindDashController : MonoBehaviour
{
    [HideInInspector] 
    public float dashSpeed = 20.0f;
    [HideInInspector]
    public float damage = 10.0f;
    [HideInInspector]
    public float speedAffect = .5f;
    private Rigidbody2D rb;
    private Vector2 dashDirection;
    private HashSet<int> enemiesDamaged = new HashSet<int>();

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        gameObject.transform.SetParent(rb.transform);
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<BoxCollider2D>().size = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().size;
        dashDirection = rb.velocity.normalized;
        var staticDashDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>().GetDirection();
        if (dashDirection.magnitude == 0)
        {
            if (staticDashDirection == "right")
            {
                dashDirection = Vector2.right;
            }
            else if (staticDashDirection == "left")
            {
                dashDirection = Vector2.left;
            }
            else if (staticDashDirection == "up")
            {
                dashDirection = Vector2.up;
            }
            else if (staticDashDirection == "down")
            {
                dashDirection = Vector2.down;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = dashDirection * dashSpeed;
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (!enemiesDamaged.Contains(collision.gameObject.GetInstanceID()))
            {
                enemiesDamaged.Add(collision.gameObject.GetInstanceID());
                enemyController.TakeDamage(damage);
            }
            enemyController.ModifySpeedByPercentage(speedAffect);
        }
    }
}
