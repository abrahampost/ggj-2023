using UnityEngine;

public class ForestLevelLoader : MonoBehaviour
{
    GameState gameState;
    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        LoadLevel();
    }

    void LoadLevel() {
        int x = gameState.selectedLevel.x;
        int y = gameState.selectedLevel.y;
        Debug.Log(string.Format("({0}, {1})", x, y));
        ForestTile.TerrainType terrainType = gameState.tiles[y][x].terrainType;
        Debug.Log(string.Format("({0}, {1}) - {2}", x, y, terrainType.ToString()));
    }
    
}