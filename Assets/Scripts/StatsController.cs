using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    private PlayerStats stats;

    public int maxHealth;
    public int speed;
    public int strength;
    public int agility;
    public int constitution;

    public float currentHealth;

    void Start()
    {
        stats = GameObject.Find("GameState").GetComponentInChildren<PlayerStats>();

        maxHealth = stats.buffedAttributes.health;
        speed = stats.buffedAttributes.speed;
        strength = stats.buffedAttributes.strength;
        agility = stats.buffedAttributes.agility;
        constitution = stats.buffedAttributes.constitution;

        currentHealth = stats.buffedAttributes.health;
    }

    public void TakeDamage(float value)
    {
        currentHealth = currentHealth - value * (10f / constitution);
    }
}
