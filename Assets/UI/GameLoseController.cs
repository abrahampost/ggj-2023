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
        ForestTile.TerrainType terrainType = gameState.tiles[gameState.selectedLevel.y][gameState.selectedLevel.x].terrainType;
        switch (terrainType) {
            case ForestTile.TerrainType.PLAIN:
                SceneManager.LoadScene("Grassland");
                break;
            case ForestTile.TerrainType.DESERT:
                SceneManager.LoadScene("Desert");
                break;
            case ForestTile.TerrainType.SWAMP:
                SceneManager.LoadScene("Swamp");
                break;
            case ForestTile.TerrainType.TUNDRA:
                SceneManager.LoadScene("Tundra");
                break;
            default:
                throw new System.Exception("Cannot load terrain type: " + terrainType.ToString());
        }
    }

    private void mainMenuButtonClicked() {
        gameState.InitializeGameState();
        SceneManager.LoadScene("MainMenu");
    }
}
