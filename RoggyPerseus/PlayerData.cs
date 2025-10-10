public class SaveFile
{
    public string UserId { get; set; }
    public string LocalDataId { get; set; }
    public PlayerStats PlayerStats { get; set; }
}

public class PlayerStats
{
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Coins { get; set; }
}