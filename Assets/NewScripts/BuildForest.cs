using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildForest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private UIDocument doc;
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    private VisualElement root;
    private VisualElement main;

    private ForestTile[][] tiles;

    [SerializeField]
    private float scale;
    [SerializeField]
    private float seed;
    void Start()
    {
        root = doc.rootVisualElement;

        main = root.Query("Grid");
        tiles = new ForestTile[height][];
        GenerateTerrain();
        DrawGrid();
    }

    void GenerateTerrain() {
        for (int i = 0; i < height; i++) {
            tiles[i] = new ForestTile[width];
            for (int j = 0; j < width; j++) {
                float sampleX = ((1f * j) / width) * scale + seed;
                float sampleY = ((1f * i) / height) * scale + seed;
                float noise = Mathf.PerlinNoise(sampleX, sampleY);
                ForestTile.TerrainType terrainType;
                if (noise < .25f) {
                    terrainType = ForestTile.TerrainType.RIVER;
                } else if (noise < .4f) {
                    terrainType = ForestTile.TerrainType.SWAMP;
                } else if (noise < .7f) {
                    terrainType = ForestTile.TerrainType.PLAIN;
                } else {
                    terrainType = ForestTile.TerrainType.MOUNTAIN;
                }
                tiles[i][j] = new ForestTile(terrainType);
            }
        }
    }

    void DrawGrid() {
        for (int i = 0; i < height; i++) {
            VisualElement row = new VisualElement();
            row.AddToClassList("row");
            for (int j = 0; j < width; j++) {
                Button button = new Button {
                    tooltip = "(" + i + ", " + j + ")"
                };
                button.AddToClassList("forest-button");
                ForestTile.TerrainType terrainType = tiles[i][j].terrainType;
                if (terrainType == ForestTile.TerrainType.RIVER) {
                    button.AddToClassList("river");
                } else if (terrainType == ForestTile.TerrainType.SWAMP) {
                    button.AddToClassList("swamp");
                } if (terrainType == ForestTile.TerrainType.PLAIN) {
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
