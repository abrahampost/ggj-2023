using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ForestLevelController : MonoBehaviour
{
    private UIDocument doc;

    GameState gameState;
    public int healthBarNumber;
    private VisualElement healthBarContainer;
    private Label agility;
    private Label constitution;
    private Label health;
    private Label speed;
    private Label strength;

    private void Awake() {
        doc = GetComponent<UIDocument>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        healthBarContainer = doc.rootVisualElement.Q<VisualElement>("Health");
        agility = doc.rootVisualElement.Q<Label>("agilityNumber");
        constitution = doc.rootVisualElement.Q<Label>("conNumber");
        health = doc.rootVisualElement.Q<Label>("healthNumber");
        speed = doc.rootVisualElement.Q<Label>("speedNumber");
        strength = doc.rootVisualElement.Q<Label>("strNumber");

        var agilityNumber = gameState.GetComponentInChildren<PlayerStats>().rawAttributes.agility + gameState.GetComponentInChildren<PlayerStats>().agilityBuff;
        agility.text = "" + agilityNumber;

        var conNumber = gameState.GetComponentInChildren<PlayerStats>().rawAttributes.constitution + gameState.GetComponentInChildren<PlayerStats>().constitutionBuff;
        constitution.text = "" + conNumber;

        var healthNumber = gameState.GetComponentInChildren<PlayerStats>().rawAttributes.health + gameState.GetComponentInChildren<PlayerStats>().healthBuff;
        health.text = "" + healthNumber;

        var speedNumber = gameState.GetComponentInChildren<PlayerStats>().rawAttributes.speed + gameState.GetComponentInChildren<PlayerStats>().speedBuff;
        speed.text = "" + speedNumber;

        var strNumber = gameState.GetComponentInChildren<PlayerStats>().rawAttributes.strength + gameState.GetComponentInChildren<PlayerStats>().strengthBuff;
        strength.text = "" + strNumber;
    }

    void Update() {
        healthBarContainer.style.maxWidth = healthBarNumber;
        var percentage = (healthBarNumber / 205) * 100;
        if (percentage > 100) {
            healthBarNumber = 205;
            healthBarContainer.style.maxWidth = healthBarNumber;
        } else if (healthBarNumber < 0) {
            healthBarNumber = 0;
            healthBarContainer.style.maxWidth = healthBarNumber;
        }
    }
    
}
