using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ProfileDoc
{
    [BsonId]
    public ObjectId Id { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;
    public int Iterations { get; set; } = 100_000;
    public int Score { get; set; } = 0;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}