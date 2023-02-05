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
        for (int y = 0; y < gameState.settings.height; y++) {
            VisualElement row = new VisualElement();
            row.AddToClassList("row");
            for (int x = 0; x < gameState.settings.width; x++) {
                Button button = new Button ();
                button.AddToClassList("forest-button");
                ForestTile selectedTile = gameState.tiles[y][x];
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
                if (gameState.playerPosition.x == x && gameState.playerPosition.y == y) {
                    VisualElement treePreview = new VisualElement();
                    treePreview.AddToClassList("player-start");
                    button.AddToClassList("highlighted-cell");
                    button.Add(treePreview);
                } else if (selectedTile.isCompleted) {
                    VisualElement treePreview = new VisualElement();
                    treePreview.AddToClassList("tree");
                    button.Add(treePreview);
                } else if (selectedTile.isPlayable
                            && Mathf.Abs(x - gameState.playerPosition.x) <= 1
                            && Mathf.Abs(y - gameState.playerPosition.y) <= 1) {
                    button.clicked += LoadLevel(x, y);
                    button.AddToClassList("clickable-tile");
                    VisualElement treePreview = new VisualElement();
                    treePreview.AddToClassList("tree");
                    treePreview.AddToClassList("tree-preview");
                    button.Add(treePreview);
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
