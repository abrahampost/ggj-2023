using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private UIDocument doc;
    private Button playButton;
    private Button settingsButton;
    private Button quitButton;

    private void Awake() {
        doc = GetComponent<UIDocument>();
        playButton = doc.rootVisualElement.Q<Button>("PlayButton");
        playButton.clicked += PlayButtonClicked;

        settingsButton = doc.rootVisualElement.Q<Button>("SettingsButton");
        settingsButton.clicked += SettingsButtonClicked;

        quitButton = doc.rootVisualElement.Q<Button>("QuitButton");
        quitButton.clicked += QuitButtonClicked;
    }

    private void PlayButtonClicked() {
        SceneManager.LoadScene("FirstLevel");
    }

    private void SettingsButtonClicked() {
        SceneManager.LoadScene("Settings");
    }

    private void QuitButtonClicked() {
        Application.Quit();
    }
}
