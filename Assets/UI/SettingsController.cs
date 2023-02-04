using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    private UIDocument doc;
    private TextField seedText;

    private TextField scaleText;

    private Button submitButton;

    private void Awake() {
        doc = GetComponent<UIDocument>();

        seedText = doc.rootVisualElement.Q<TextField>("seedText");

        scaleText = doc.rootVisualElement.Q<TextField>("scaleText");

        submitButton = doc.rootVisualElement.Q<Button>("submitButton");
        submitButton.clicked += submitButtonClicked;
    }

    private void submitButtonClicked() {
        Debug.Log(seedText.value);
        Debug.Log(scaleText.value);

        var seedValue = float.Parse(seedText.value);
        var scaleValue = float.Parse(scaleText.value);

        Debug.Log(seedValue);
        Debug.Log(scaleValue);

        if (seedValue <= 0) {
            seedValue = 1;
            seedText.value = "Please set a number between 1 and 10,000";
        } else if (seedValue > 10000) {
            seedValue = 1;
            seedText.value = "Please set a number between 1 and 10,000";
        }

        if (scaleValue <= 0) {
            scaleValue = 1;
            scaleText.value = "Please set a number between 1 and 5";
        } else if (scaleValue > 5) {
            scaleValue = 1;
            scaleText.value = "Please set a number between 1 and 5";
        }
    }
}
