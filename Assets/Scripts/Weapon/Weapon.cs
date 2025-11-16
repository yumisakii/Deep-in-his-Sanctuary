using System.Collections.Generic;
using System.Linq;


public class Weapon
{
    public string Name { get; private set; }
    public float Damage { get; private set; }
    public int FusionTier { get; private set; } = 0;
    public Tiers Tier { get; private set; }

    public Skill Skill { get; private set; }

    public Dictionary<ElementType, int> Elements { get; private set; }

    // --- UI ---
    public string WeaponIconName { get; private set; }
    public string SpellIconName { get; private set; }


    public Weapon(string name, float damage, int fusionTier, Tiers tier, Skill skill, Dictionary<ElementType, int> elements, string weaponIcon, string spellIcon)
    {
        Name = name;
        Damage = damage;
        FusionTier = fusionTier;
        Tier = tier;
        Skill = skill;
        Elements = elements;
        WeaponIconName = weaponIcon;
        SpellIconName = spellIcon;
    }

    public bool IsUltimateWeapon()
    {
        int distinctFullElements = Elements.Keys.Count(el => el >= ElementType.Fire);

        return distinctFullElements >= 9;
    }

    public bool IsUltimateElement(ElementType type, out int stackCount)
    {
        stackCount = GetStackCount(type);
        return stackCount >= 9;
    }

    public int GetStackCount(ElementType type)
    {
        if (Elements.ContainsKey(type))
        {
            return Elements[type];
        }
        return 0;
    }
}

public class Skill
{
    public string Name { get; set; } = "defaultSkill";
    public float Damage { get; set; } = 10f;
    public bool IsAOE { get; set; } = true;
}

