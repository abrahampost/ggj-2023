using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    GameState gameState;
    private UIDocument doc;
    private TextField seedText;

    private TextField scaleText;

    private Button submitButton;

    void OnMouseEnter()
    {
        UnityEngine.Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
    private void Awake() {
        doc = GetComponent<UIDocument>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        

        seedText = doc.rootVisualElement.Q<TextField>("seedText");
        seedText.value = "" + gameState.settings.seed;

        scaleText = doc.rootVisualElement.Q<TextField>("scaleText");
        scaleText.value = "" + gameState.settings.scale;

        submitButton = doc.rootVisualElement.Q<Button>("submitButton");
        submitButton.clicked += submitButtonClicked;
    }

    private void submitButtonClicked() {

        int seedValue = (int) Mathf.Floor(float.Parse(seedText.value));
        int scaleValue = (int) Mathf.Floor(float.Parse(scaleText.value));

        if (seedValue <= 0) {
            seedValue = 1;
            seedText.value = "Please set a number between 1 and 10,000";
        } else if (seedValue > 10000) {
            seedValue = 1;
            seedText.value = "Please set a number between 1 and 10,000";
        } else {
            gameState.settings.seed = seedValue;
            SceneManager.LoadScene("MainMenu");
        }

        if (scaleValue <= 0) {
            scaleValue = 1;
            scaleText.value = "Please set a number between 1 and 5";
        } else if (scaleValue > 5) {
            scaleValue = 1;
            scaleText.value = "Please set a number between 1 and 5";
        } else {
            gameState.settings.scale = scaleValue;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
