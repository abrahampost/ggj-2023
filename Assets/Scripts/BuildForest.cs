using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BuildForest : MonoBehaviour
{

    GameState gameState;

    [SerializeField]
    private UIDocument doc;

    public Texture2D cursorTexture;

    private VisualElement root;
    private VisualElement main;


    void Start()
    {
        UnityEngine.Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
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

    void OnMouseEnter() {
        UnityEngine.Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }


    private void DrawGrid() {
        for (int i = 0; i < gameState.settings.height; i++) {
            VisualElement row = new VisualElement();
            row.AddToClassList("row");
            for (int j = 0; j < gameState.settings.width; j++) {
                Button button = new Button ();
                button.AddToClassList("forest-button");
                ForestTile selectedTile = gameState.tiles[i][j];
                ForestTile.TerrainType terrainType = selectedTile.terrainType;
                if (terrainType == ForestTile.TerrainType.RIVER) {
                    button.AddToClassList("river");
                } else if (terrainType == ForestTile.TerrainType.SWAMP) {
                    button.AddToClassList("swamp");
                } else if (terrainType == ForestTile.TerrainType.PLAIN) {
                    button.AddToClassList("plain");
                } else if (terrainType == ForestTile.TerrainType.TUNDRA) {
                    button.AddToClassList("tundra"); 
                } else {
                    button.AddToClassList("mountain"); 
                }
                // if (selectedTile.completed) {
                    VisualElement treePreview = new VisualElement();
                    treePreview.AddToClassList("tree-preview");
                    button.Add(treePreview);
                // }
                if (selectedTile.isPlayable) {
                    button.clicked += LoadLevel(j, i);
                }
                row.Add(button);
            }
            main.Add(row);
        }
    }

    private System.Action LoadLevel(int x, int y) {
        return () => {
            gameState.selectedLevel.x = x;
            gameState.selectedLevel.y = y;
            SceneManager.LoadScene("ForestLevel");
        };
    }

}
