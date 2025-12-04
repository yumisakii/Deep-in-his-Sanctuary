using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveData
{
    // --- META PROGRESSION (Kept after death) ---
    public int totalRunsPlayed;
    public int enemiesKilled;
    // Add things like "unlockedWeapons" here later

    // --- CURRENT RUN STATE (Reset on death) ---
    public bool isRunActive;
    public int currentRoomIndex;
    public float currentHealth;
    public float currentMaxHealth;

    // We cannot save the Weapon class directly because of the Dictionary.
    // We use a list of simplified data structs instead.
    public List<WeaponSaveData> inventory = new List<WeaponSaveData>();
}

[System.Serializable]
public class WeaponSaveData
{
    public string name;
    public float damage;
    public int fusionTier; // 0, 1, 2...
    public int rarity;     // Cast enum to int

    // Skill data (simplified for now)
    public string skillName;
    public float skillDamage;
    public bool skillIsAOE;

    // The workaround for Dictionary: A list of simple pairs
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