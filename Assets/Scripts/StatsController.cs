using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    private PlayerStats stats;

    public int biomeStatsBase = 5;
    public int maxHealth;
    public int speed;
    public int strength;
    public int agility;
    public int constitution;
    public int desertBoost;
    public int tundraBoost;
    public int swampBoost;
    public int plainBoost;

    public float currentHealth;

    void Start()
    {
        stats = GameObject.Find("GameState").GetComponentInChildren<PlayerStats>();

        maxHealth = stats.buffedAttributes.health;
        speed = stats.buffedAttributes.speed;
        strength = stats.buffedAttributes.strength;
        agility = stats.buffedAttributes.agility;
        constitution = stats.buffedAttributes.constitution;



        desertBoost = stats.desertBoost + biomeStatsBase;
        tundraBoost = stats.tundraBoost + biomeStatsBase;
        swampBoost = stats.swampBoost + biomeStatsBase;
        plainBoost = stats.plainBoost + biomeStatsBase;

        currentHealth = maxHealth;
    }

    public void TakeDamage(float value)
    {
        currentHealth = currentHealth - value * (10f / constitution);
        // Debug.Log(value);
        Debug.Log(currentHealth);

        gameObject.transform.parent.GetComponent<MovementController>().Blink();

        // SetColor(new Color(100, 0, 0));

        // StartCoroutine(ResetColor());
        // IEnumerator ResetColor()
        // {
        //     yield return new WaitForSecondsRealtime(0.2f);
        //     SetColor(originColor);
        // }

        // if (health <= 0)
        // {
        //     // agent.speed = 0;
        //     soundController.playDeathScream();
        //     animationController.DeathAnimation();
        //     // Destroy(gameObject, 1.0f);
        //     return;
        // }
    }
}
