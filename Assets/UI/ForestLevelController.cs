using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ForestLevelController : MonoBehaviour
{
    private UIDocument doc;
    public int Health;
    private VisualElement health;

    private void Awake() {
        doc = GetComponent<UIDocument>();

        health = doc.rootVisualElement.Q<VisualElement>("Health");
        
    }

    void Update() {
        health.style.maxWidth = Health;
        if (Health > 205) {
            Health = 205;
            health.style.maxWidth = Health;
        } else if (Health < 0) {
            Health = 0;
            health.style.maxWidth = Health;
        }
    }
    
}
