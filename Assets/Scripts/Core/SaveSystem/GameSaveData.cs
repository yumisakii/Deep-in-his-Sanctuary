using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveData
{
    public int totalRunsPlayed;
    public int enemiesKilled;

    public bool isRunActive;
    public int currentRoomIndex;
    public float currentHealth;
    public float currentMaxHealth;

    public List<WeaponSaveData> inventory = new List<WeaponSaveData>();
}

[System.Serializable]
public class WeaponSaveData
{
    public string name;
    public float damage;
    public int fusionTier;
    public int rarity;

    public string skillName;
    public float skillDamage;
    public bool skillIsAOE;

    public List<ElementSaveStack> elements = new List<ElementSaveStack>();

    public string iconName;
    public string spellIconName;
}

[System.Serializable]
public struct ElementSaveStack
{
    public ElementType type;
    public int count;

    public ElementSaveStack(ElementType type, int count)
    {
        this.type = type;
        this.count = count;
    }
}