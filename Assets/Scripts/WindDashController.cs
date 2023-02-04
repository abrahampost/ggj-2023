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
    private Rigidbody2D player;
    private Vector2 dashDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        dashDirection = player.velocity.normalized;
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + dashDirection * dashSpeed * Time.deltaTime);
    }
}
