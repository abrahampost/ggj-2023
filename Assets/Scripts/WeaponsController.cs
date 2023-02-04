using System;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public float globalCooldown = .5f;
    private bool isOnGlobalCooldown = false;

    [Header("Melee")]
    public GameObject melee;
    public KeyCode meleeKeyBind;
    public float meleeCooldown = 2.0f;
    private bool isMeleeOnCooldown = false;

    [Header("Fireball")]
    public GameObject fireball;
    public KeyCode fireballKeyBind;
    public float fireballCooldown = 2.0f;
    private bool isFireballOnCooldown = false;

    [Header("Cone of Cold")]
    public GameObject coneOfCold;
    public KeyCode coneOfColdKeyBind;
    public float coneOfColdCooldown = 2.0f;
    private bool isConeOfColdOnCooldown = false;

    [Header("Dash")]
    public GameObject dash;
    public KeyCode dashKeyBind;
    public float dashCooldown = 2.0f;
    private bool isDashOnCooldown = false;

    [Header("Thorns")]
    public GameObject thorns;
    public KeyCode thornsKeyBind;
    public float thornsCooldown = 2.0f;
    private bool isThornsOnCooldown = false;

    // Update is called once per frame
    private void Update()
    {
        if (!isOnGlobalCooldown)
        {
            if (Input.GetKey(meleeKeyBind) && !isMeleeOnCooldown)
            {
                Instantiate(melee, transform.position, transform.rotation);
                isMeleeOnCooldown = true;
                isOnGlobalCooldown = true;
                Task.Delay(TimeSpan.FromSeconds(meleeCooldown)).ContinueWith((task) => isMeleeOnCooldown = false);
                Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
            }

            else if (Input.GetKey(fireballKeyBind) && !isFireballOnCooldown)
            {
                Instantiate(fireball, transform.position, transform.rotation);
                isFireballOnCooldown = true;
                isOnGlobalCooldown = true;
                Task.Delay(TimeSpan.FromSeconds(fireballCooldown)).ContinueWith((task) => isFireballOnCooldown = false);
                Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
            }

            else if (Input.GetKey(coneOfColdKeyBind) && !isConeOfColdOnCooldown)
            {
                Instantiate(coneOfCold, transform.position, transform.rotation);
                isConeOfColdOnCooldown = true;
                isOnGlobalCooldown = true;
                Task.Delay(TimeSpan.FromSeconds(coneOfColdCooldown)).ContinueWith((task) => isConeOfColdOnCooldown = false);
                Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
            }

            else if (Input.GetKey(dashKeyBind) && !isDashOnCooldown)
            {
                Instantiate(dash, transform.position, transform.rotation);
                isDashOnCooldown = true;
                isOnGlobalCooldown = true;
                Task.Delay(TimeSpan.FromSeconds(dashCooldown)).ContinueWith((task) => isDashOnCooldown = false);
                Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
            }

            else if (Input.GetKey(thornsKeyBind) && !isThornsOnCooldown)
            {
                Instantiate(thorns, transform.position, transform.rotation);
                isThornsOnCooldown = true;
                isOnGlobalCooldown = true;
                Task.Delay(TimeSpan.FromSeconds(dashCooldown)).ContinueWith((task) => isThornsOnCooldown = false);
                Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
            }
        }
    }
}
