using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BossLevelController : MonoBehaviour
{
    private UIDocument doc;
    private StatsController statsHealth;
    private PlayerStats stats;
    // GameState gameState;
    public int healthBarNumber;
    private VisualElement health;
    private VisualElement talkingHead;

    private void Awake() {
        Debug.Log("Starting");
        doc = GetComponent<UIDocument>();
        // gameState = GameObject.Find("GameState").GetComponent<GameState>();
        stats = GameObject.Find("GameState").GetComponentInChildren<PlayerStats>();
        statsHealth = GameObject.FindObjectOfType<StatsController>();

        health = doc.rootVisualElement.Q<VisualElement>("Health");
        talkingHead = doc.rootVisualElement.Q<VisualElement>("talkingHeadFrame");
    }

    void Start() {
        StartCoroutine(HideTalkingHead());
    }

    IEnumerator HideTalkingHead() {
        yield return new WaitForSeconds(3);
        talkingHead.visible = false;
    }

    void Update() {
        healthBarNumber = (int) Mathf.Floor(100 * (float) statsHealth.currentHealth / (float) statsHealth.maxHealth);
        health.style.maxWidth = Length.Percent(healthBarNumber);
        if (healthBarNumber > 100) {
            healthBarNumber = 100;
            health.style.maxWidth = Length.Percent(100);
        } else if (healthBarNumber < 0) {
            healthBarNumber = 0;
            health.style.maxWidth = Length.Percent(0);
        }
    }
}
