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
                InstantiateMelee();
            }

            else if (Input.GetKey(fireballKeyBind) && !isFireballOnCooldown)
            {
                InstantiateFireball();
            }

            else if (Input.GetKey(coneOfColdKeyBind) && !isConeOfColdOnCooldown)
            {
                InstantiateConeOfCold();
            }

            else if (Input.GetKey(dashKeyBind) && !isDashOnCooldown)
            {
                InstantiateDash();
            }

            else if (Input.GetKey(thornsKeyBind) && !isThornsOnCooldown)
            {
                InstantiateThorns();
            }
        }
    }

    private void InstantiateMelee()
    {
        InstantiateObject(melee);
        isMeleeOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(meleeCooldown)).ContinueWith((task) => isMeleeOnCooldown = false);
    }

    private void InstantiateFireball()
    {
        InstantiateObject(fireball);
        isFireballOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(fireballCooldown)).ContinueWith((task) => isFireballOnCooldown = false);
    }

    private void InstantiateConeOfCold()
    {
        InstantiateObject(coneOfCold);
        isConeOfColdOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(coneOfColdCooldown)).ContinueWith((task) => isConeOfColdOnCooldown = false);
    }

    private void InstantiateDash()
    {
        InstantiateObject(dash);
        isDashOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(dashCooldown)).ContinueWith((task) => isDashOnCooldown = false);
    }

    private void InstantiateThorns()
    {
        InstantiateObject(thorns);
        isThornsOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(thornsCooldown)).ContinueWith((task) => isThornsOnCooldown = false);
    }

    private void InstantiateObject(GameObject gameObject) 
    {
        Instantiate(gameObject, transform.position, transform.rotation);
        isOnGlobalCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
    }
}
