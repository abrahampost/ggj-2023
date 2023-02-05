using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [HideInInspector]
    public float damage = 10.0f;
    [HideInInspector]
    public float speedAffect = .5f;
    private Rigidbody2D rb;
    public GameObject parent;

    void Start()
    {
        // Debug.Log("slashy washy");
        rb = parent.GetComponent<Rigidbody2D>();
        gameObject.transform.SetParent(rb.transform);
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<BoxCollider2D>().size = parent.GetComponent<BoxCollider2D>().size;
    }

    // private void FixedUpdate()
    // {
        // rb.velocity = dashDirection * dashSpeed;
    // }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Debug.Log("Boom boom pow");
            var playerController = collision.gameObject.GetComponent<MovementController>();
            // if (!enemiesDamaged.Contains(collision.gameObject.GetInstanceID()))
            // {
                // enemiesDamaged.Add(collision.gameObject.GetInstanceID());
                playerController.TakeDamage(damage);
            // }
            // enemyController.ModifySpeedByPercentage(speedAffect);
        }
    }
}
