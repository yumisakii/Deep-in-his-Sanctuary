using MongoDB.Bson.Serialization.Attributes;

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