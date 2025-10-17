using MongoDB.Bson;
using MongoDB.Driver;
using RoggyPerseus.SaveFolder;

public static class MongoManager
{
    private static MongoContext? context;

    public static async Task InitServer()
    {
        try
        {
            context = new MongoContext("mongodb://localhost:27017", "roggyPerseus");

            await context.Db.RunCommandAsync<MongoDB.Bson.BsonDocument>(new MongoDB.Bson.BsonDocument("ping", 1));

            Console.WriteLine("\nConnection with MongoDB initialized.");
        }
        catch (MongoDB.Driver.MongoConnectionException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Unable to connect to MongoDB.");
            Console.WriteLine($"Details : {ex.Message}\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An unexpected error occurred during MongoDB initialization.");
            Console.WriteLine($"Details: {ex.Message}\n");
            Console.ResetColor();
        }
    }

    public static async Task CreateProfile(string username, string password)
    {
        if (context == null)
            throw new InvalidOperationException("MongoManager is not initialized.");

        var existing = await context.Profiles.Find(p => p.Username == username).FirstOrDefaultAsync();

        if (existing != null)
        {
            Console.WriteLine("This username is already taken");
            return;
        }

        var (hashB64, saltB64) = PasswordManager.HashPassword(password);

        var newProfile = new ProfileDoc
        {
            Id = ObjectId.GenerateNewId(),
            Username = username,
            PasswordHash = hashB64,
            PasswordSalt = saltB64,
            Iterations = 100_000,

            Score = Run.playerStats.BestScore,

            CreatedUtc = DateTime.UtcNow,
        };

        await context.Profiles.InsertOneAsync(newProfile);
        Console.WriteLine($"Profile {username} created");
    }

    public static async Task<ProfileDoc?> LoadProfile(string username, string password)
    {
        if (context == null)
            throw new InvalidOperationException("MongoManager is not initialized.");

        // Get profile with username
        var profile = await context.Profiles.Find(p => p.Username == username).FirstOrDefaultAsync();

        if (profile == null)
            return null;

        // Check password
        bool valid = PasswordManager.VerifyPassword(password, profile.PasswordHash, profile.PasswordSalt);

        return valid ? profile : null;
    }

    public static async Task UpdateProfile(string username, int newScore)
    {
        if (context == null)
            throw new InvalidOperationException("MongoManager is not initialized.");

        var filter = Builders<ProfileDoc>.Filter.Eq(p => p.Username, username);

        // Check if the profile exist
        var profile = await context.Profiles.Find(filter).FirstOrDefaultAsync();
        if (profile == null)
        {
            Console.WriteLine($"No profile found for {username}.\n");
            return;
        }

        var update = Builders<ProfileDoc>.Update
            .Set(p => p.Score, newScore)
            .Set(s => s.CreatedUtc, DateTime.UtcNow);
        var result = await context.Profiles.UpdateOneAsync(filter, update);

        if (result.ModifiedCount > 0)
        {
            Console.WriteLine($"Score for {username} updated to {newScore}.");
        }
        else
        {
            Console.WriteLine($"Score for {username} unchanged.");
        }
    }

    public static async Task<List<ProfileDoc>> GetLeaderboardProfiles()
    {
        if (context == null)
        {
            Console.WriteLine("MongoManager is not initialized.");
            return new List<ProfileDoc>();
        }

        try
        {
            Console.WriteLine("Fetching profiles for leaderboard...");

            // Récupère tous les profils triés par score décroissant
            var profiles = await context.Profiles
                .Find(FilterDefinition<ProfileDoc>.Empty)
                .SortByDescending(p => p.Score)
                .ToListAsync();

            Console.WriteLine($"{profiles.Count} profiles retrieved.");
            return profiles;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        return new List<ProfileDoc>();
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