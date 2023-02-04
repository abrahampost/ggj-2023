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
    public float meleeCooldown;
    public float meleeTime;
    private bool isMeleeOnCooldown = false;

    [Header("Fireball")]
    public GameObject fireball;
    public KeyCode fireballKeyBind;
    public float fireballCooldown;
    public float fireballSpeed;
    public float fireballSecondsAlive;
    public float fireballStartingDistance;
    private bool isFireballOnCooldown = false;

    [Header("Cone of Cold")]
    public GameObject coneOfCold;
    public KeyCode coneOfColdKeyBind;
    public float coneOfColdCooldown;
    public float coneOfColdSecondsAlive; 
    public float coneOfColdStartingDistance;
    private bool isConeOfColdOnCooldown = false;

    [Header("Dash")]
    public GameObject dash;
    public KeyCode dashKeyBind;
    public float dashCooldown;
    public float dashTime;
    public float dashSpeed;
    private bool isDashOnCooldown = false;

    [Header("Thorns")]
    public GameObject thorns;
    public KeyCode thornsKeyBind;
    public float thornsCooldown;
    public float thornsSecondsAlive;
    public float thornsMinDistance;
    public float thornsMaxDistance;
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
        var meleeObject = InstantiateObject(melee);
        isMeleeOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(meleeCooldown)).ContinueWith((task) => isMeleeOnCooldown = false);
        meleeObject.GetComponent<MeleeController>().meleeTime = meleeTime;
    }

    private void InstantiateFireball()
    {
        var fireballObject = InstantiateObject(fireball);
        isFireballOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(fireballCooldown)).ContinueWith((task) => isFireballOnCooldown = false);
        fireballObject.GetComponent<FireballController>().speed = fireballSpeed;
        fireballObject.GetComponent<FireballController>().secondsAlive = fireballSpeed;
        fireballObject.GetComponent<FireballController>().startingDistance = fireballStartingDistance;
    }

    private void InstantiateConeOfCold()
    {
        var coneOfColdObject = InstantiateObject(coneOfCold);
        isConeOfColdOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(coneOfColdCooldown)).ContinueWith((task) => isConeOfColdOnCooldown = false);
        coneOfColdObject.GetComponent<ConeOfColdController>().secondsAlive = coneOfColdSecondsAlive;
        coneOfColdObject.GetComponent<ConeOfColdController>().startingDistance = coneOfColdStartingDistance;
    }

    private void InstantiateDash()
    {
        var dashObject = InstantiateObject(dash);
        isDashOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(dashCooldown)).ContinueWith((task) => isDashOnCooldown = false);
        dashObject.GetComponent<WindDashController>().dashSpeed = dashSpeed;
        dashObject.GetComponent<WindDashController>().dashTime = dashTime;
    }

    private void InstantiateThorns()
    {
        var thornsObject = InstantiateObject(thorns);
        isThornsOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(thornsCooldown)).ContinueWith((task) => isThornsOnCooldown = false);
        thornsObject.GetComponent<ThornsController>().secondsAlive = thornsSecondsAlive;
        thornsObject.GetComponent<ThornsController>().minDistance = thornsMinDistance;
        thornsObject.GetComponent<ThornsController>().maxDistance = thornsMaxDistance;
    }

    private GameObject InstantiateObject(GameObject gameObject) 
    {
        GameObject newObject = Instantiate(gameObject, transform.position, transform.rotation);
        isOnGlobalCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(globalCooldown)).ContinueWith((task) => isOnGlobalCooldown = false);
        return newObject;
    }
}
