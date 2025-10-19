//using System.Text;

//public class JsonSaveLoad
//{
//    private static readonly string saveFilePath = "savefile.json";

//    public static void SaveGame(ObjectId userId, int localDataId, PlayerStats stats)
//    {
//        List<SaveFile> allSaves = new();

//        if (File.Exists(saveFilePath))
//        {
//            string json = File.ReadAllText(saveFilePath);
//            try
//            {
//                allSaves = JsonSerializer.Deserialize<List<SaveFile>>(json) ?? new List<SaveFile>();
//            }
//            catch
//            {
//                allSaves = new List<SaveFile>();
//            }
//        }

//        var existing = allSaves.Find(s => s.localDataId == localDataId);
//        if (existing != null)
//        {
//            existing.userId = userId;
//            existing.PlayerStats = stats;
//        }
//        else
//        {
//            allSaves.Add(new SaveFile
//            {
//                userId = userId,
//                localDataId = localDataId,
//                PlayerStats = stats
//            });
//        }

//        string newJson = JsonSerializer.Serialize(allSaves, new JsonSerializerOptions { WriteIndented = true });
//        string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(newJson));
//        File.WriteAllText(saveFilePath, encoded);


//        Console.WriteLine($"Game saved successfully (Local ID : {localDataId}).\n");
//    }

//    public static SaveFile? LoadGame(int targetLocalDataId)
//    {
//        if (!File.Exists(saveFilePath))
//        {
//            Console.WriteLine("No save file found.");
//            return null;
//        }

//        string encoded = File.ReadAllText(saveFilePath);
//        string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
//        List<SaveFile>? allSaves = JsonSerializer.Deserialize<List<SaveFile>>(decoded);


//        if (allSaves == null || allSaves.Count == 0)
//        {
//            Console.WriteLine("No valid save data found.");
//            return null;
//        }

//        var found = allSaves.Find(s => s.localDataId == targetLocalDataId);
//        if (found != null)
//        {
//            Console.WriteLine($"Game loaded. Local ID: {found.localDataId}. Room: {found.PlayerStats.currentRoom}");
//            return found;
//        }
//        Console.WriteLine($"No save found with LocalDataId = {targetLocalDataId}");
//        return null;
//    }
//}
