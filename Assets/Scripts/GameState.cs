using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static bool instantiated;
    public ForestTile[][] tiles;

    [System.Serializable]
    public struct Settings {
        public int seed;
        public int width;
        public int height;
        public int scale;
    }


    public struct SelectedLevel {
        public int x;
        public int y;
    }

    public Settings settings;
    public SelectedLevel selectedLevel;
    public Vector2 playerPosition;
    public Vector2 goalPosition;
    public int levelsCompleted = 0;

    void Awake() {
        if (instantiated) {
            Destroy(this);
            return;
        }
        instantiated = true;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        settings = new Settings {
            height = 16,
            width = 16,
            seed = Random.Range(1, 10000),
            scale = 3
        };
        GetComponentInChildren<AudioSource>().Play();
        Debug.Log("Seed is " + settings.seed);
    }

    public void GenerateTerrain() {
        // This should make the below placement all repeatable based on seed
        Random.InitState(settings.seed);

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
                } else if (noise < .6f) {
                    terrainType = ForestTile.TerrainType.PLAIN;
                } else if (noise < .7f) {
                    terrainType = ForestTile.TerrainType.DESERT;
                } else if (noise < .8f) {
                    terrainType = ForestTile.TerrainType.TUNDRA;
                } else {
                    terrainType = ForestTile.TerrainType.MOUNTAIN;
                }
                tiles[i][j] = new ForestTile(terrainType);
            }
        }
        PlacePlayer();
        PlaceGoal();
    }

    void PlacePlayer() {
        ForestTile selectedTile;
        // TODO: If it can't find a valid start tile, instead of looping forever change seed and try again
        do {
            int randomHeight = Random.Range(0, settings.height);
            selectedTile = tiles[randomHeight][0];
            playerPosition = new Vector2(0, randomHeight);
        } while (selectedTile.terrainType == ForestTile.TerrainType.MOUNTAIN || selectedTile.terrainType == ForestTile.TerrainType.RIVER);
        selectedTile.isCompleted = true;
    }

    void PlaceGoal() {
        ForestTile selectedTile;
        // TODO: If it can't find a valid goal tile, instead of looping forever change seed and try again
        do {
            int randomHeight = Random.Range(0, settings.height);
            selectedTile = tiles[randomHeight][settings.width - 1];
            goalPosition = new Vector2(0, randomHeight);
        } while (selectedTile.terrainType == ForestTile.TerrainType.MOUNTAIN || selectedTile.terrainType == ForestTile.TerrainType.RIVER);
        selectedTile.isGoal = true;
    }

}
