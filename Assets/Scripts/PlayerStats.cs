using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{

    public enum AttributeTypes {
        HEALTH,
        CONSTITUTION,
        STRENGTH,
        SPEED,
        AGILITY
    }
    public struct Attributes {
        public int health;
        public int constitution;
        public int strength;
        public int speed;
        public int agility;
    }

    public Attributes rawAttributes = new Attributes {
        agility = 10,
        constitution = 10,
        health = 10,
        speed = 10,
        strength = 10
    };

    public Attributes buffedAttributes {
        get {
            return new Attributes {
                health = rawAttributes.health + healthBuff,
                agility = rawAttributes.agility + agilityBuff,
                constitution = rawAttributes.constitution + constitutionBuff,
                speed = rawAttributes.speed + speedBuff,
                strength = rawAttributes.strength + strengthBuff
            };
        }
    }


    public int healthBuff = 0;
    public int constitutionBuff = 0;
    public int strengthBuff = 0;
    public int speedBuff = 0;
    public int agilityBuff = 0;
    private List<BuffBase> baseBuffs = new List<BuffBase>();

    // Just in case we want to ever do anything with them

    public int tundraBoost = 0;
    public int plainBoost = 0;
    public int swampBoost = 0;
    public int desertBoost = 0;
    private List<BuffWeapon> weaponBuffs = new List<BuffWeapon>();

    public void AddBaseBuff(BuffBase buff, bool save = true) {
        if (save) {
            baseBuffs.Add(buff);
        }
        foreach (BuffBase.Modifier modifier in buff.modifiers) {
            switch (modifier.modifierType) {
                case "AGILITY":
                    agilityBuff += modifier.modifierValue;
                    break;
                case "HEALTH":
                    healthBuff += modifier.modifierValue;
                    break;
                case "STRENGTH":
                    strengthBuff += modifier.modifierValue;
                    break;
                case "CONSTITUTION":
                    constitutionBuff += modifier.modifierValue;
                    break;
                case "SPEED:":
                    speedBuff += modifier.modifierValue;
                    break;
                default:
                    break;
            }
        }
    }

    public void AddWeaponBuff(BuffWeapon buff) {
        weaponBuffs.Add(buff);
        switch (buff.terrainType) {
            case "PLAIN":
                plainBoost += buff.weaponModifier;
                break;
            case "SWAMP":
                swampBoost += buff.weaponModifier;
                break;
            case "TUNDRA":
                tundraBoost += buff.weaponModifier;
                break;
            case "DESERT":
                desertBoost += buff.weaponModifier;
                break;
            default:
                throw new System.Exception("Unsupported Terrain Type Upgrade" + buff.terrainType.ToString());
        }
        AddBaseBuff(buff);
    }

}
