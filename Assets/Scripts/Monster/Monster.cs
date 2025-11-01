public class Monster
{
    public string Name { get; set; } = "baseMonster";
    public string IconName { get; set; } = "Monster_01";
    public DangerLevel DangerLevel { get; set; } = DangerLevel.Grey;
    public float Health { get; set; } = 100f;
    public float MaxHealth { get; set; } = 100f;
    public float Damage { get; set; } = 10f;

    public bool IsAlive { get; set; } = true;
}
