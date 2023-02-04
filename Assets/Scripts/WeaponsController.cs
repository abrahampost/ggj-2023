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

    private WeaponSoundController soundController;

    private void Start()
    {
        soundController = GetComponent<WeaponSoundController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown(gunKeyBind) && !isGunOnCooldown)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            isGunOnCooldown = true;
            Task.Delay(TimeSpan.FromSeconds(gunCooldown)).ContinueWith((task) => isGunOnCooldown = false);

            soundController.PlayProjectileLaunch(gunCooldown);
        }
    }
}
