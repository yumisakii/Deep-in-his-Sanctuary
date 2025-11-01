using UnityEngine;

// This static class contains the logic to create a runtime Weapon 
// from its base data, applying necessary scaling.
public static class WeaponBuilder
{
    public static Weapon BuildWeapon(WeaponData data)
    {

        Weapon newWeapon = new Weapon
        {
            Name = data.weaponName,            
            Damage = data.damage,
            WeaponIconName = data.weaponIconName,
            SpellIconName = data.spellIconName,
            Rarity = data.rarity,
            Skill = data.skill
        };

        return newWeapon;
    }
}
