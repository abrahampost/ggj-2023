using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameWinController : MonoBehaviour
{
    private UIDocument doc;

    private GameState gameState;

    private Label planted;

    private Button mainMenuButton;

    private void Awake() {
        doc = GetComponent<UIDocument>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        planted = doc.rootVisualElement.Q<Label>("planted");
        planted.text = "Trees planted: " + gameState.levelsCompleted;

        mainMenuButton = doc.rootVisualElement.Q<Button>("mainMenuButton");
        mainMenuButton.clicked += mainMenuButtonClicked;
    }

    private void mainMenuButtonClicked() {
        SceneManager.LoadScene("MainMenu");
    }
}
