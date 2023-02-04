using System;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [HideInInspector]
    public float meleeSpeed = 1.0f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var animationController = player.GetComponent<AnimationController>();

        animationController.AttackAnimation(meleeSpeed);
    }
}
