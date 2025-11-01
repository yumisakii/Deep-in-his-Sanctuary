
public class Weapon
{
    public string Name { get; set; } = "defaultWeapon";
    public float Damage { get; set; } = 10f;
    public Skill Skill { get; set; } = new Skill();
    public string WeaponIconName { get; set; } = "";
    public string SpellIconName { get; set; } = "";
    public Rarity Rarity { get; set; } = Rarity.Gray;
}

public class Skill
{
    public string Name { get; set; } = "defaultSkill";
    public float Damage { get; set; } = 10f;
    public bool IsAOE { get; set; } = true;
}

