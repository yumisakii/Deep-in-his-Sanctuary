public class Monster
{
    public string Name { get; set; } = "baseMonster";
    public string IconName { get; set; } = "Monster_01";
    public DangerLevel DangerLevel { get; set; } = DangerLevel.Grey;
    public float Hp { get; set; } = 10f;
    public float Damage { get; set; } = 10f;

    public Monster(string name, string iconName, DangerLevel dangerLevel)
    {
        Name = name;
        IconName = iconName;
        DangerLevel = dangerLevel;
    }
}
