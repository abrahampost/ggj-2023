using System;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [HideInInspector]
    public float meleeTime = .5f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var animationController = player.GetComponent<AnimationController>();
        animationController.AttackAnimation(1.0f);

        Destroy(gameObject, meleeTime);
    }

    private void FixedUpdate()
    {

    }
}
