using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushColorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var gameState = GameObject.Find("GameState").GetComponent<GameState>();
        ForestTile.TerrainType terrainType;
        int x;
        int y;

        if (gameState.tiles == null)
        {
            terrainType = ForestTile.TerrainType.DESERT;
        } else
        {
            x = gameState.selectedLevel.x;
            y = gameState.selectedLevel.y;
            terrainType = gameState.tiles[y][x].terrainType;
        }

        if (terrainType == ForestTile.TerrainType.TUNDRA)
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(180 / 256f, 35 / 256f, 0 / 256f);
        } else if (terrainType == ForestTile.TerrainType.SWAMP)
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color (40 / 256f, 150 / 256f, 0 / 256f);
        } else if (terrainType == ForestTile.TerrainType.DESERT)
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(231 / 256f, 43 / 256f, 48 / 256f);
        } else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }
}
