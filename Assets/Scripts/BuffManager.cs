using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [System.Serializable]
    public class BuffList {
        public List<BuffBase> baseBuffs;
        public List<BuffWeapon> weaponBuffs;

    }
    
    public BuffList buffList;

    void Awake() {
        TextAsset rawJson = Resources.Load("Buffs") as TextAsset;
        buffList = JsonUtility.FromJson<BuffList>(rawJson.text);
    }

    public BuffBase[] GetRandomBaseBuffs() {
        int length = buffList.baseBuffs.Count;
        int firstItem = Random.Range(0, length);
        int secondItem = Random.Range(0, length);
        while (secondItem == firstItem) {
            // Make sure they aren't the same buff
            secondItem = Random.Range(0, length);
        }

        return new BuffBase[] { buffList.baseBuffs[firstItem], buffList.baseBuffs[secondItem] };
    }

    public BuffWeapon GetRandomWeaponBuffForTerrain(ForestTile.TerrainType terrainType) {
        List<BuffWeapon> validWeaponBuffs = buffList.weaponBuffs.FindAll((buff) => {
            return buff.terrainType == terrainType.ToString();
        });
        int randomIndex = Random.Range(0, validWeaponBuffs.Count);
        return validWeaponBuffs[randomIndex];
    }

    
}