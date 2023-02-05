using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameLoseController : MonoBehaviour
{
   private GameState gameState;

   private UIDocument doc;

   private Button backButton;

   private Button tryAgainButton;

   private Button mainMenuButton;

   private Label endVictory;

   private int planted;

   private void Awake() {
        doc = GetComponent<UIDocument>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        planted = gameState.levelsCompleted;
        endVictory.text = endVictory.text + "You saved " + planted + "trees";

        backButton = doc.rootVisualElement.Q<Button>("backButton");
        tryAgainButton = doc.rootVisualElement.Q<Button>("againButton");
        mainMenuButton = doc.rootVisualElement.Q<Button>("mainMenuButton");
        
   }
    private void Start() {
        backButton.clicked += backButtonClicked;
        tryAgainButton.clicked += tryAgainButtonClicked;
        mainMenuButton.clicked += mainMenuButtonClicked;
   }
    private void backButtonClicked() {
        SceneManager.LoadScene("ForestSelection");
    }

    private void tryAgainButtonClicked() {
        // load last scene?
        // SceneManager.LoadScene("")
    }

    private void mainMenuButtonClicked() {
        Debug.Log("MAIN MENU PUSHED");
        SceneManager.LoadScene("MainMenu");
    }
}
