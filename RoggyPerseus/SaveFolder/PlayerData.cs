using MongoDB.Bson;
public class SaveFile
{
    public ObjectId userId { get; set; } = default!;
    public int localDataId { get; set; } = 1;
    public PlayerStats PlayerStats { get; set; } = new PlayerStats();
}

public class PlayerStats
{
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Coins { get; set; }
}