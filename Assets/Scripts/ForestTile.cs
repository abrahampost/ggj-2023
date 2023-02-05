using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTile
{

    public ForestTile(TerrainType terrainType) {
        this.terrainType = terrainType; 
    }

    public enum TerrainType {
        RIVER,
        MOUNTAIN,
        PLAIN,
        SWAMP,
        TUNDRA
    }

    public TerrainType terrainType;
    public bool isCompleted;

    public bool isPlayable {
        get {
            return (terrainType == TerrainType.PLAIN
                || terrainType == TerrainType.SWAMP
                || terrainType == TerrainType.TUNDRA)
                && !isCompleted;
        }
    }
}
