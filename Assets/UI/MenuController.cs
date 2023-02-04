using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=8w0qvO4Vumc - Create Game Menu like a PRO using UI Toolkit - PitilT

public class MenuController : MonoBehaviour
{
    private UIDocument doc;
    private Button playButton;
    private Button settingsButton;
    private Button quitButton;

    GameState gameState;

    private void Awake() {
        doc = GetComponent<UIDocument>();
        playButton = doc.rootVisualElement.Q<Button>("PlayButton");
        playButton.clicked += PlayButtonClicked;

        settingsButton = doc.rootVisualElement.Q<Button>("SettingsButton");
        settingsButton.clicked += SettingsButtonClicked;

        quitButton = doc.rootVisualElement.Q<Button>("QuitButton");
        quitButton.clicked += QuitButtonClicked;
    }

    void Start() {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    private void PlayButtonClicked() {
        gameState.GenerateTerrain();
        SceneManager.LoadScene("ForestSelection");
    }

    private void SettingsButtonClicked() {
        SceneManager.LoadScene("SettingsPage");
    }

    private void QuitButtonClicked() {
        Application.Quit();
    }
}
