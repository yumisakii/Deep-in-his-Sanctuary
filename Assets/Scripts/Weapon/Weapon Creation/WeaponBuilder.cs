using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public static class WeaponBuilder
{
    public static Weapon BuildWeapon(WeaponData data)
    {
        var newElements = new Dictionary<ElementType, int>();
        if (data.element != ElementType.None)
        {
            newElements.Add(data.element, 1);
        }

        string name = "Broken Axe";
        int fusionTier = 0;

        Skill newSkill = new Skill();

        Weapon newWeapon = new Weapon(
        
            name,
            data.damage,
            fusionTier,
            data.tier,
            newSkill,
            newElements,
            data.weaponIconName,
            data.spellIconName
        );

        return newWeapon;
    }

    public static Weapon FuseWeapons(Weapon weaponA, Weapon weaponB)
    {
        // --- RULE 1: TIER CHECK ---
        if (weaponA.FusionTier != weaponB.FusionTier)
        {
            Debug.LogWarning("Fusion Failed: Tiers do not match.");
            return null;
        }

        int currentTier = weaponA.FusionTier;
        int newTier;
        var newElements = new Dictionary<ElementType, int>();

        // --- RULE 2: FUSION LOGIC (TIER 0 -> TIER 1) ---
        if (currentTier == 0)
        {
            ElementType elementA = GetFirstElement(weaponA);
            ElementType elementB = GetFirstElement(weaponB);

            if (elementA != ElementType.None && elementA == elementB)
            {
                ElementType fullElement = GetFullElement(elementA);
                if (fullElement == ElementType.None) return null;

                newElements.Add(fullElement, 1);
                newTier = 1;
            }
            else
            {
                Debug.LogWarning("Fusion Failed: Sub-elements do not match.");
                return null;
            }
        }

        // --- RULE 3: FUSION LOGIC (TIER 1+ -> TIER N+) ---
        else
        {
            MergeDictionaries(newElements, weaponA.Elements);
            MergeDictionaries(newElements, weaponB.Elements);

            newTier = currentTier + 1;
        }

        // --- POST-FUSION CALCULATIONS ---
        float newDamage = (weaponA.Damage + weaponB.Damage) * 1.15f; // Will change that in the future

        // --- Naming Logic ---
        string newName;
        Weapon tempCheck = new Weapon(null, 0, 0, Tiers.Gray, null, newElements, null, null);

        if (tempCheck.IsUltimateWeapon())
        {
            newName = "Ultimate Axe";
        }
        else if (newTier >= 3)
        {
            newName = "Great Axe";
        }
        else if (newTier == 2)
        {
            newName = "Axe";
        }
        else
        {
            newName = "Broken Axe";
        }

        // --- Skill Fusion (Placeholder) ---
        Skill newSkill = new Skill
        {
            Name = weaponA.Skill.Name,
            Damage = weaponA.Skill.Damage,
            IsAOE = weaponA.Skill.IsAOE
        };

        // --- Rarity (Placeholder) ---
        Tiers newTierEnum = weaponA.Tier;

        // --- Create the final, new currentWeapon ---
        return new Weapon(
            newName,
            newDamage,
            newTier,
            newTierEnum,
            newSkill,
            newElements,
            weaponA.WeaponIconName,
            weaponA.SpellIconName
        );
    }

    private static void MergeDictionaries(Dictionary<ElementType, int> target, Dictionary<ElementType, int> source)
    {
        if (target == null || source == null) return;
        foreach (var pair in source)
        {
            if (target.ContainsKey(pair.Key))
                target[pair.Key] += pair.Value;
            else
                target.Add(pair.Key, pair.Value);
        }
    }

    private static ElementType GetFirstElement(Weapon weapon)
    {
        if (weapon.Elements == null || weapon.Elements.Count == 0)
            return ElementType.None;
        return weapon.Elements.Keys.FirstOrDefault();
    }

    private static ElementType GetFullElement(ElementType subElement)
    {
        switch (subElement)
        {
            case ElementType.Ember: return ElementType.Fire;
            case ElementType.Toxin: return ElementType.Poison;
            case ElementType.Frost: return ElementType.Ice;
            case ElementType.Nick: return ElementType.Bleed;
            case ElementType.Spark: return ElementType.Lightning;
            case ElementType.Thirst: return ElementType.Vampirism;
            case ElementType.Shadow: return ElementType.Void;
            case ElementType.Gnaw: return ElementType.Corrode;
            case ElementType.SnipSnip: return ElementType.Cull;
            default:
                Debug.LogError($"Invalid Sub-Element for conversion: {subElement}");
                return ElementType.None;
        }
    }

    public static Weapon BuildWeaponFromSave(WeaponSaveData saveData)
    {
        var elements = new Dictionary<ElementType, int>();
        foreach (var stack in saveData.elements)
        {
            if (elements.ContainsKey(stack.type))
                elements[stack.type] += stack.count;
            else
                elements.Add(stack.type, stack.count);
        }

        Skill skill = new Skill
        {
            Name = saveData.skillName,
            Damage = saveData.skillDamage,
            IsAOE = saveData.skillIsAOE
        };

        return new Weapon(
            saveData.name,
            saveData.damage,
            saveData.fusionTier,
            (Tiers)saveData.rarity,
            skill,
            elements,
            saveData.iconName,
            saveData.spellIconName
        );
    }
}