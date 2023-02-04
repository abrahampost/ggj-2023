using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [Header("Gun")]
    public GameObject bullet;
    public string gunKeyBind;
    public float gunCooldown = 2.0f;
    private bool isGunOnCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(gunKeyBind) && !isGunOnCooldown)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            isGunOnCooldown = true;
            Task.Delay(TimeSpan.FromSeconds(gunCooldown)).ContinueWith((task) => isGunOnCooldown = false);
        }
    }
}
