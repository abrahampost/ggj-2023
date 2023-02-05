using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BuildForest : MonoBehaviour
{

    GameState gameState;
    PlayerStats playerStats;

    [SerializeField]
    private UIDocument doc;

    private VisualElement root;
    private VisualElement grid;


    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();

        root = doc.rootVisualElement;

        grid = root.Query("Grid");
        DrawGrid();
        UpdateStats();
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
                } else if (terrainType == ForestTile.TerrainType.DESERT) {
                    button.AddToClassList("desert");
                } else {
                    button.AddToClassList("mountain"); 
                }

                if (gameState.playerPosition.x == x && gameState.playerPosition.y == y) {
                    VisualElement treePreview = new VisualElement();
                    treePreview.AddToClassList("player-start");
                    button.AddToClassList("highlighted-cell");
                    button.Add(treePreview);
                } else if (selectedTile.isGoal) {
                    VisualElement goalTile = new VisualElement();
                    goalTile.AddToClassList("goal-tile");
                    if (Mathf.Abs(x - gameState.playerPosition.x) <= 1
                            && Mathf.Abs(y - gameState.playerPosition.y) <= 1) {
                        button.AddToClassList("clickable-tile");
                        button.clicked += () => SceneManager.LoadScene("BossFight");
                    }
                    button.Add(goalTile);
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
            grid.Add(row);
        }
    }
    private void UpdateStats() {
        Label healthStat = root.Q<Label>("HealthStat");
        healthStat.text = string.Format("Health: {0}", playerStats.buffedAttributes.health);
        Label strengthStat = root.Q<Label>("StrengthStat");
        strengthStat.text = string.Format("Strength: {0}", playerStats.buffedAttributes.strength);
        Label agilityStat = root.Q<Label>("AgilityStat");
        agilityStat.text = string.Format("Agility: {0}", playerStats.buffedAttributes.agility);
        Label constitutionStat = root.Q<Label>("ConstitutionStat");
        constitutionStat.text = string.Format("Constitution: {0}", playerStats.buffedAttributes.constitution);
        Label speedStat = root.Q<Label>("SpeedStat");
        speedStat.text = string.Format("Speed: {0}", playerStats.buffedAttributes.speed);

        Label tundraStat = root.Q<Label>("ConeOfColdStat");
        tundraStat.text = string.Format("Cone of Cold: {0}", playerStats.tundraBoost);
        Label plainStat = root.Q<Label>("WindDashStat");
        plainStat.text = string.Format("Wind Dash: {0}", playerStats.plainBoost);
        Label swampStat = root.Q<Label>("ThornsStat");
        swampStat.text = string.Format("Thorn Stat: {0}", playerStats.swampBoost);
        Label desertStat = root.Q<Label>("FireballStat");
        desertStat.text = string.Format("Fireball: {0}", playerStats.desertBoost);
    }

    private System.Action LoadLevel(int x, int y) {
        return () => {
            gameState.selectedLevel.x = x;
            gameState.selectedLevel.y = y;
            ForestTile.TerrainType terrainType = gameState.tiles[y][x].terrainType;
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
        };
    }

}
