using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public ForestTile[][] tiles;


    public struct Settings {
        public int seed;
        public int width;
        public int height;
        public int scale;
    }

    public Settings settings;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        settings = new Settings {
            height = 16,
            width = 24,
            seed = 84,
            scale = 3
        };
    }

    public void GenerateTerrain() {
        tiles = new ForestTile[settings.height][];
        for (int i = 0; i < settings.height; i++) {
            tiles[i] = new ForestTile[settings.width];
            for (int j = 0; j < settings.width; j++) {
                float sampleX = ((1f * j) / settings.width) * settings.scale + settings.seed;
                float sampleY = ((1f * i) / settings.height) * settings.scale + settings.seed;
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

}
