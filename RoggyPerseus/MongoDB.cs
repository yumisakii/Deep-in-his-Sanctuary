using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using RoggyPerseus;

public static class MongoManager
{
    private static MongoContext? context;

    public static Task InitServer()
    {
        context = new MongoContext("mongodb://localhost:27017", "roggyPerseus");
        Console.WriteLine("Connexion MongoDB initialisée\n");
        return Task.CompletedTask;
    }

    public static async Task CreateProfile(string username, string password)
    {
        if (context == null)
            throw new InvalidOperationException("MongoManager n'est pas initialisé.");

        var existing = await context.Profiles.Find(p => p.Username == username).FirstOrDefaultAsync();
        if (existing != null)
        {
            Console.WriteLine("Ce nom d'utilisateur est déjà pris\n");
            return;
        }

        var (hashB64, saltB64) = PasswordManager.HashPassword(password);

        var newProfile = new ProfileDoc
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Username = username,
            PasswordHash = hashB64,
            PasswordSalt = saltB64,
            Iterations = 100_000,
            CreatedUtc = DateTime.UtcNow,
        };

        await context.Profiles.InsertOneAsync(newProfile);
        Console.WriteLine($"\nProfil {username} créé\n");
    }

    public static async Task<ProfileDoc?> LoadProfile(string username, string password)
    {
        if (context == null)
            throw new InvalidOperationException("MongoManager n'est pas initialisé.");

        // Get profile with username
        var profile = await context.Profiles.Find(p => p.Username == username).FirstOrDefaultAsync();

        if (profile == null)
            return null;

        // Check password
        bool valid = PasswordManager.VerifyPassword(password, profile.PasswordHash, profile.PasswordSalt);

        return valid ? profile : null;
    }
}

public class MongoContext
{
    public IMongoDatabase Db { get; }
    public IMongoCollection<ProfileDoc> Profiles => Db.GetCollection<ProfileDoc>("profiles");

    public MongoContext(string connexionString, string dbName)
    {
        var settings = MongoClientSettings.FromConnectionString(connexionString);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(3);
        settings.ConnectTimeout = TimeSpan.FromSeconds(3);
        settings.WaitQueueTimeout = TimeSpan.FromSeconds(5);

        var client = new MongoClient(settings);
        Db = client.GetDatabase(dbName);
    }
}

public class ProfileDoc
{
    [BsonId]
    public string Id { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;
    public int Iterations { get; set; } = 100_000;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}

//public class SaveDoc
//{
//    [BsonId]
//    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
//    public string Username { get; set; } = default!;
//    public int Score { get; set; } = 0;
//    public DateTime UpdatedUtc { get; set; } = DateTime.UtcNow;
//}