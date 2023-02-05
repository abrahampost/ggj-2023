using System;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class WeaponsController : MonoBehaviour
{
    public float globalCooldown = .5f;
    private bool isOnGlobalCooldown = false;
    private GameObject player;
    private StatsController stats;

    [Header("Melee")]
    public GameObject melee;
    public KeyCode meleeKeyBind;
    public float meleeCooldown;
    public float meleeTime;
    public int meleeDamage;
    private bool isMeleeOnCooldown = false;
    [HideInInspector]
    public bool isMeleeing = false;

    [Header("Fireball")]
    public GameObject fireball;
    public KeyCode fireballKeyBind;
    public float fireballCooldown;
    public float fireballSpeed;
    public float fireballSecondsAlive;
    public float fireballStartingDistance;
    public int fireballDamage;
    public float fireballSpeedAffect;
    private bool isFireballOnCooldown = false;

    [Header("Cone of Cold")]
    public GameObject coneOfCold;
    public KeyCode coneOfColdKeyBind;
    public float coneOfColdCooldown;
    public float coneOfColdSecondsAlive; 
    public float coneOfColdSize;
    public float coneOfColdStartingDistance;
    public int coneOfColdDamage;
    public float coneOfColdSpeedAffect;
    private bool isConeOfColdOnCooldown = false;

    [Header("Dash")]
    public GameObject dash;
    public KeyCode dashKeyBind;
    public float dashCooldown;
    public float dashTime;
    public float dashSpeed;
    private bool isDashOnCooldown = false;
    public int dashDamage;
    public float dashSpeedAffect;
    [HideInInspector]
    public bool isDashing = false;

    [Header("Thorns")]
    public GameObject thorns;
    public KeyCode thornsKeyBind;
    public float thornsCooldown;
    public float thornsSecondsAlive;
    public float thornsDistance;
    public int thornsDamage;
    public float thornsSpeedAffect;
    private bool isThornsOnCooldown = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = FindObjectOfType<StatsController>();
        globalCooldown = globalCooldown * (10 / stats.agility);
    }

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
        var meleeObject = InstantiateObject(melee, meleeTime);
        isMeleeOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(meleeCooldown)).ContinueWith((task) => isMeleeOnCooldown = false);
        Task.Delay(TimeSpan.FromSeconds(meleeTime)).ContinueWith((task) => Destroy(meleeObject));

        isMeleeing = true;
        StartCoroutine(MakePlayerNotTrigger());

        IEnumerator MakePlayerNotTrigger()
        {
            yield return new WaitForSecondsRealtime(meleeTime);
            isMeleeing = false;
        }

        //meleeObject.GetComponent<MeleeController>().meleeSpeed = 1/meleeTime;
        meleeObject.GetComponent<MeleeController>().damage = meleeDamage * (stats.strength / 10);
    }

    private void InstantiateFireball()
    {
        var fireballObject = InstantiateObject(fireball, fireballSecondsAlive);
        isFireballOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(fireballCooldown)).ContinueWith((task) => isFireballOnCooldown = false);
        fireballObject.GetComponent<FireballController>().speed = fireballSpeed;
        fireballObject.GetComponent<FireballController>().startingDistance = fireballStartingDistance;
        fireballObject.GetComponent<FireballController>().damage = fireballDamage;
        fireballObject.GetComponent<FireballController>().speedAffect = fireballSpeedAffect;
    }

    private void InstantiateConeOfCold()
    {
        var coneOfColdObject = InstantiateObject(coneOfCold, coneOfColdSecondsAlive);
        isConeOfColdOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(coneOfColdCooldown)).ContinueWith((task) => isConeOfColdOnCooldown = false);
        coneOfColdObject.GetComponentInChildren<ConeOfColdController>().startingDistance = coneOfColdStartingDistance;
        coneOfColdObject.GetComponentInChildren<ConeOfColdController>().damage = coneOfColdDamage;
        coneOfColdObject.GetComponentInChildren<ConeOfColdController>().speedAffect = coneOfColdSpeedAffect;
        coneOfColdObject.GetComponentInChildren<ConeOfColdController>().size = coneOfColdSize;
    }

    private void InstantiateDash()
    {
        var dashObject = InstantiateObject(dash, dashTime);
        isDashOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(dashCooldown)).ContinueWith((task) => isDashOnCooldown = false);
        dashObject.GetComponent<WindDashController>().dashSpeed = dashSpeed;
        dashObject.GetComponent<WindDashController>().damage = dashDamage;
        dashObject.GetComponent<WindDashController>().speedAffect = dashSpeedAffect;

        isDashing = true;
        player.GetComponent<BoxCollider2D>().isTrigger = true;
        StartCoroutine(MakePlayerNotTrigger());

        IEnumerator MakePlayerNotTrigger()
        {
            yield return new WaitForSecondsRealtime(dashTime);
            isDashing = false;
            player.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void InstantiateThorns()
    {
        var thornsObject = InstantiateObject(thorns, thornsSecondsAlive);
        isThornsOnCooldown = true;
        Task.Delay(TimeSpan.FromSeconds(thornsCooldown)).ContinueWith((task) => isThornsOnCooldown = false);
        thornsObject.GetComponentInChildren<ThornsController>().secondsAlive = thornsSecondsAlive;
        thornsObject.GetComponentInChildren<ThornsController>().distance = thornsDistance;
        thornsObject.GetComponentInChildren<ThornsController>().damage = thornsDamage;
        thornsObject.GetComponentInChildren<ThornsController>().speedAffect = thornsSpeedAffect;
    }

    private GameObject InstantiateObject(GameObject gameObject, float secondsAlive) 
    {
        GameObject newObject = Instantiate(gameObject, transform.position, transform.rotation);

        isOnGlobalCooldown = true;
        StartCoroutine(OffGlobalCooldown());
        IEnumerator OffGlobalCooldown()
        {
            yield return new WaitForSecondsRealtime(globalCooldown);
            isOnGlobalCooldown = false;
        }

        Destroy(newObject, secondsAlive);
        return newObject;
    }
}
