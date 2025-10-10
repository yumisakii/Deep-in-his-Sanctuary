using System;
using System.IO;
using System.Text.Json;

public class JsonSaveLoad
{
    private static readonly string saveFilePath = "savefile.json";

    public static void SaveGame(string userId, int localDataId, PlayerStats stats)
    {
        SaveFile saveFileData = new SaveFile
        {
            userId = userId,
            localDataId = localDataId,
            PlayerStats = stats
        };

        string json = JsonSerializer.Serialize(saveFileData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(saveFilePath, json);

        Console.WriteLine("✅ Game saved successfully.\n");
    }

    public static SaveFile LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveFile data = JsonSerializer.Deserialize<SaveFile>(json);

            Console.WriteLine($"✅ Game loaded. User ID: {data.userId}, Local ID: {data.localDataId}");
            return data;
        }
        else
        {
            Console.WriteLine("❌ No save file found.");
            return null;
        }
    }
}
