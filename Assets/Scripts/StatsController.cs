using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        maxHealth = stats.buffedAttributes.health * 2;
        speed = stats.buffedAttributes.speed * 2;
        strength = stats.buffedAttributes.strength * 2;
        agility = stats.buffedAttributes.agility * 2;
        constitution = stats.buffedAttributes.constitution * 2;



        desertBoost = stats.desertBoost + biomeStatsBase;
        tundraBoost = stats.tundraBoost + biomeStatsBase;
        swampBoost = stats.swampBoost + biomeStatsBase;
        plainBoost = stats.plainBoost + biomeStatsBase;

        currentHealth = maxHealth;
    }

    public void TakeDamage(float value)
    {
        currentHealth = currentHealth - value * (10f / constitution);
        // Debug.Log(currentHealth);

        gameObject.transform.parent.GetComponent<MovementController>().Blink();
        // stats = GameObject.Find("GameState").GetComponentInChildren<PlayerStats>();

        if (currentHealth <= 0)
        {
            gameObject.transform.parent.GetComponent<PlayerSoundController>().playDeathScream();
            gameObject.transform.parent.GetComponent<AnimationController>().DeathAnimation();
            StartCoroutine(WaitForDeath());
        }
    }

    private IEnumerator WaitForDeath() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EndGameLose");
    }
}
