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

            Console.WriteLine("Connexion MongoDB initialisée avec succès.\n");
        }
        catch (MongoDB.Driver.MongoConnectionException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erreur : impossible de se connecter à MongoDB.");
            Console.WriteLine($"Détails : {ex.Message}\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Une erreur inattendue est survenue lors de l'initialisation de MongoDB.");
            Console.WriteLine($"Détails : {ex.Message}\n");
            Console.ResetColor();
        }
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
            Id = ObjectId.GenerateNewId(),
            Username = username,
            PasswordHash = hashB64,
            PasswordSalt = saltB64,
            Iterations = 100_000,

            Score = Run.playerStats.BestScore,

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

    public static async Task UpdateProfile(string username, int newScore)
    {
        if (context == null)
            throw new InvalidOperationException("MongoManager n'est pas initialisé.");

        var filter = Builders<ProfileDoc>.Filter.Eq(p => p.Username, username);

        // Check if the profile exist
        var profile = await context.Profiles.Find(filter).FirstOrDefaultAsync();
        if (profile == null)
        {
            Console.WriteLine($"Aucun profil trouvé pour {username}.\n");
            return;
        }

        var update = Builders<ProfileDoc>.Update
            .Set(p => p.Score, newScore)
            .Set(s => s.CreatedUtc, DateTime.UtcNow);
        var result = await context.Profiles.UpdateOneAsync(filter, update);

        if (result.ModifiedCount > 0)
        {
            Console.WriteLine($"Score de {username} mis à jour à {newScore}.");
        }
        else
        {
            Console.WriteLine($"Score de {username} inchangé.");
        }
    }

    public static async Task<List<ProfileDoc>> GetLeaderboardProfiles()
    {
        if (context == null)
        {
            Console.WriteLine("MongoManager n'est pas initialisé.");
            return new List<ProfileDoc>();
        }

        try
        {
            Console.WriteLine("Récupération des profils pour le leaderboard...");

            // Récupère tous les profils triés par score décroissant
            var profiles = await context.Profiles
                .Find(FilterDefinition<ProfileDoc>.Empty)
                .SortByDescending(p => p.Score)
                .ToListAsync();

            Console.WriteLine($"{profiles.Count} profils récupérés.");
            return profiles;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur inattendue : {ex.Message}");
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