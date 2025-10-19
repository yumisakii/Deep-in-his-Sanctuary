public class SaveFile
{
    public string Username { get; set; } = "";
    
    [JsonIgnore]
    public ObjectId userId { get; set; } = default!;
    public int localDataId { get; set; } = 1;
    public PlayerStats PlayerStats { get; set; } = new PlayerStats();
}

public class PlayerStats
{
    // Permanant Stats
    public float MaxHp { get; set; } = 10f;
    public float DamageModifier { get; set; } = 1f;
    public int BestScore { get; set; } = 0;

    // Stats to reset
    public float Hp { get; set; } = 10f;
    public int currentRoom { get; set; } = 1;
    public List<Weapon> Inventory { get; set; } = new List<Weapon>();
    public int Score { get; set; } = 0;

    public static void InitPlayerStats(PlayerStats playerStats)
    {
        playerStats.Hp = playerStats.MaxHp;
        playerStats.currentRoom = 1;
        playerStats.Inventory.Clear();
        playerStats.Score = 0;
    }
}