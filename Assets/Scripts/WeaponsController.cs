using System;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public float globalCooldown = .5f;
    private bool isOnGlobalCooldown = false;
    
    [Header("Primary Fire")]
    public GameObject fireball;
    public string fireballKeyBind;
    public float fireballCooldown = 2.0f;
    private bool isFireballOnCooldown = false;

    [Header("Secondary Fire")]
    public GameObject coneOfCold;
    public string coneOfColdKeyBind;
    public float coneOfColdCooldown = 2.0f;
    private bool isConeOfColdOnCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (!isOnGlobalCooldown)
        {
            if (Input.GetButtonDown(fireballKeyBind) && !isFireballOnCooldown)
            {
                Instantiate(fireball, transform.position, transform.rotation);
                isFireballOnCooldown = true;
                isOnGlobalCooldown = true;
                Task.Delay(TimeSpan.FromSeconds(fireballCooldown)).ContinueWith((task) => isFireballOnCooldown = false);
                Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
            }

            else if (Input.GetButtonDown(coneOfColdKeyBind) && !isConeOfColdOnCooldown)
            {
                Instantiate(coneOfCold, transform.position, transform.rotation);
                isConeOfColdOnCooldown = true;
                isOnGlobalCooldown = true;
                Task.Delay(TimeSpan.FromSeconds(coneOfColdCooldown)).ContinueWith((task) => isConeOfColdOnCooldown = false);
                Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
            }
        }
    }
}
