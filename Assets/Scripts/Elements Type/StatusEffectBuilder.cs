using UnityEngine;
using System.Collections.Generic;

public static class StatusEffectBuilder
{
    private static List<StatusEffectData> StatusEffectDataList = new List<StatusEffectData>();
    public static StatusEffect BuildStatusEffect(ElementType type, float sourceDamage, int stackCount)
    {
        StatusEffectData data = GetStatusEffectDataFromDatabase(type);
        if (data == null) return null;

        StatusEffect statusEffect = new StatusEffect(
            type,
            data.Damage,
            data.TurnsRemaining
            );

        statusEffect.SetStacks(stackCount);

        statusEffect.SetSourceDamage(sourceDamage);

        return statusEffect;
    }

    private static StatusEffectData GetStatusEffectDataFromDatabase(ElementType type)
    {
        Debug.Log("Data List Count: " + StatusEffectDataList.Count);

        foreach (StatusEffectData data in StatusEffectDataList)
        {
            Debug.Log("Iterating through StatusEffectDataList...");
            Debug.Log("Looking for Type: " + type);
            Debug.Log("Checking StatusEffectData: " + data.Type);
            if (data.Type == type)
                return data;
        }
        return null;
    }


    public static void InitAllStatusEffects(List<StatusEffectData> statusEffectDataList)
    {
        StatusEffectDataList = statusEffectDataList;
    }
}