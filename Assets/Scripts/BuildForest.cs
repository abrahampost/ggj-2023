using UnityEngine;
using UnityEngine.UIElements;

public class BuildForest : MonoBehaviour
{

    GameState gameState;

    [SerializeField]
    private UIDocument doc;

    private VisualElement root;
    private VisualElement main;


    [SerializeField]
    private float scale;

    void Start()
    {
        GameObject go = GameObject.Find("GameState");
        if (go == null) {
            go = new GameObject("GameState");
            go.AddComponent<GameState>();
            gameState = go.GetComponent<GameState>();
            gameState.settings = new GameState.Settings {
                height = 16,
                width = 24,
                scale = 3,
                seed = 3
            };
            gameState.GenerateTerrain();
        } else {
            gameState = go.GetComponent<GameState>();
        }
        root = doc.rootVisualElement;

        main = root.Query("Grid");
        DrawGrid();
    }


    void DrawGrid() {
        for (int i = 0; i < gameState.settings.height; i++) {
            VisualElement row = new VisualElement();
            row.AddToClassList("row");
            for (int j = 0; j < gameState.settings.width; j++) {
                Button button = new Button {
                    tooltip = "(" + i + ", " + j + ")"
                };
                button.AddToClassList("forest-button");
                ForestTile.TerrainType terrainType = gameState.tiles[i][j].terrainType;
                if (terrainType == ForestTile.TerrainType.RIVER) {
                    button.AddToClassList("river");
                } else if (terrainType == ForestTile.TerrainType.SWAMP) {
                    button.AddToClassList("swamp");
                } else if (terrainType == ForestTile.TerrainType.PLAIN) {
                    button.AddToClassList("plain");
                } else {
                    button.AddToClassList("mountain"); 
                }
                button.clicked += () => {
                    Debug.Log(string.Join(", ", button.GetClasses()));
                };
                row.Add(button);
            }
            main.Add(row);
        }
    }

}
