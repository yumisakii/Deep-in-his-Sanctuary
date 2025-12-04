using UnityEngine;
using System.IO;
using System.Collections.Generic;

public static class SaveManager
{
    private static string SaveFileName = "DeepSanctuarySave.json";

    public static void SaveGame()
    {
        GameSaveData data = new GameSaveData();

        // 1. Save Meta Data (You'll need a place to store this, maybe GameManager?)
        // data.totalRunsPlayed = ... 

        // 2. Save Player Stats
        if (PlayerManager.Instance != null && PlayerManager.Instance.Player != null)
        {
            data.currentHealth = PlayerManager.Instance.Player.GetHealth();
            data.currentMaxHealth = PlayerManager.Instance.Player.GetMaxHealth();
        }

        // 3. Save Inventory (The Tricky Part)
        if (Inventory.Instance != null)
        {
            data.inventory = ConvertInventoryToSaveData(Inventory.Instance.GetInventory());
        }

        data.isRunActive = true;

        // 4. Write to File
        string json = JsonUtility.ToJson(data, true); // 'true' makes it readable
        string path = Path.Combine(Application.persistentDataPath, SaveFileName);
        File.WriteAllText(path, json);

        Debug.Log($"Game Saved to: {path}");
    }

    public static GameSaveData LoadGame()
    {
        string path = Path.Combine(Application.persistentDataPath, SaveFileName);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameSaveData data = JsonUtility.FromJson<GameSaveData>(json);
            return data;
        }
        else
        {
            return null; // No save found
        }
    }

    public static void DeleteSave()
    {
        string path = Path.Combine(Application.persistentDataPath, SaveFileName);
        if (File.Exists(path))
        {
            // Ideally, we keep the Meta Data and only reset the Run Data.
            // For now, we just delete it.
            File.Delete(path);
        }
    }

    // --- CONVERTERS ---

    private static List<WeaponSaveData> ConvertInventoryToSaveData(List<Weapon> runtimeInventory)
    {
        List<WeaponSaveData> saveDataList = new List<WeaponSaveData>();

        foreach (Weapon w in runtimeInventory)
        {
            WeaponSaveData wData = new WeaponSaveData();
            wData.name = w.Name;
            wData.damage = w.Damage;
            wData.fusionTier = w.FusionTier;
            wData.rarity = (int)w.Tier;
            wData.iconName = w.WeaponIconName;
            wData.spellIconName = w.SpellIconName;

            // Skill
            if (w.Skill != null)
            {
                wData.skillName = w.Skill.Name;
                wData.skillDamage = w.Skill.Damage;
                wData.skillIsAOE = w.Skill.IsAOE;
            }

            // Convert Dictionary -> List for JSON
            foreach (var pair in w.Elements)
            {
                wData.elements.Add(new ElementSaveStack(pair.Key, pair.Value));
            }

            saveDataList.Add(wData);
        }

        return saveDataList;
    }
}