using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAttacks : MonoBehaviour
{
    private WeaponsController controller;
    private void Start()
    {
        controller = GameObject.FindObjectOfType<WeaponsController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (controller.isMeleeing)
        {
            Debug.Log("Melee Attack");
        }

        if (controller.isDashing)
        {
            Debug.Log("Dash Attack");
        }
    }
}
