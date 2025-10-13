using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonSaveLoad
{
    private static readonly string saveFilePath = "savefile.json";

    public static void SaveGame(string userId, int localDataId, PlayerStats stats)
    {
        List<SaveFile> allSaves = new();

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            try
            {
                allSaves = JsonSerializer.Deserialize<List<SaveFile>>(json) ?? new List<SaveFile>();
            }
            catch
            {
                allSaves = new List<SaveFile>();
            }
        }

        var existing = allSaves.Find(s => s.localDataId == localDataId);
        if (existing != null)
        {
            existing.userId = userId;
            existing.PlayerStats = stats;
        }
        else
        {
            allSaves.Add(new SaveFile
            {
                userId = userId,
                localDataId = localDataId,
                PlayerStats = stats
            });
        }

        string newJson = JsonSerializer.Serialize(allSaves, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(saveFilePath, newJson);

        Console.WriteLine($"Game saved successfully (Local ID : {localDataId}).\n");
    }

    public static SaveFile? LoadGame(int targetLocalDataId)
    {
        if (!File.Exists(saveFilePath))
        {
            Console.WriteLine("No save file found.");
            return null;
        }

        string json = File.ReadAllText(saveFilePath);
        List<SaveFile>? allSaves = JsonSerializer.Deserialize<List<SaveFile>>(json);
        
        if (allSaves == null || allSaves.Count == 0)
        {
            Console.WriteLine("No valid save data found.");
            return null;
        }

        var found = allSaves.Find(s => s.localDataId == targetLocalDataId);
        if (found != null)
        {
            Console.WriteLine($"Game loaded. User ID: {found.userId}, Local ID: {found.localDataId}");
            return found;
        }
        Console.WriteLine($"No save found with LocalDataId = {targetLocalDataId}");
        return null;
    }
}
