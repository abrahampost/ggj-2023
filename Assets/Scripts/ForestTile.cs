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
        SWAMP
    }

    public TerrainType terrainType;
}
