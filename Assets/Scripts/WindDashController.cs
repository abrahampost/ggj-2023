using System;
using System.Collections.Generic;
using UnityEngine;

public class WindDashController : MonoBehaviour
{
    public float dashTime = 1.0f;
    public float dashSpeed = 20.0f;
    private Rigidbody2D player;
    private Vector2 dashDirection;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        dashDirection = new Vector2(player.transform.forward.x, player.transform.forward.y);

        Destroy(gameObject, dashTime);
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + Vector2.left * dashSpeed * Time.deltaTime);
    }
}
