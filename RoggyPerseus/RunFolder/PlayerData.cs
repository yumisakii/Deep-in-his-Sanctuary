using MongoDB.Bson;
public class SaveFile
{
    public string Username { get; set; } = "";
    public ObjectId userId { get; set; } = default!;
    public int localDataId { get; set; } = 1;
    public PlayerStats PlayerStats { get; set; } = new PlayerStats();
}

public class PlayerStats
{
    public float Hp { get; set; } = 10f;
    public float MaxHp { get; set; } = 10f;
    public float DamageModifier { get; set; } = 1f;

    public int BestScore { get; set; } = 0;
    public int Score { get; set; } = 0;


    public static void InitPlayerStats(PlayerStats playerStats)
    {
        playerStats.Hp = playerStats.MaxHp;
        playerStats.Score = 0;
    }
}