using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    // Stats
    public float Health { get; set; } = 100f;
    public float MaxHealth { get; set; } = 100f;
    public float Damage { get; set; } = 10f;
    public float BaseDamage { get; set; } = 10f;
    public float Armor { get; set; } = 10f;
    public float BaseArmor { get; set; } = 10f;
    public float QTESpeed { get; set; } = 1;

    // UI
    public string Name { get; set; } = "baseMonster";
    public string IconName { get; set; } = "Monster_01";

    // Other
    public List<StatusEffect> ActiveEffects { get; set; } = new List<StatusEffect>();
    public bool IsAlive { get; set; } = true;

    public void TakeDamage(float amount)
    {
        Health -= amount; // Armor here

        if (Health <= 0 && IsAlive)
            Health = 0;

        Debug.Log($"{Name} took {amount} damges and has {Health} health left.");
    }

    public void ApplyStatus(StatusEffect newEffect)
    {
        for (int i = 0; i < ActiveEffects.Count; i++)
        {
            if (ActiveEffects[i].Type == newEffect.Type)
            {
                ActiveEffects[i].AddOneStack();
                ActiveEffects[i].SetTurnRemaining(newEffect.TurnsRemaining);
                return;
            }
        }

        ActiveEffects.Add(newEffect);
    }

    public void ProcessTurnEffects()
    {
        for (int i = ActiveEffects.Count - 1; i >= 0; i--)
        {
            StatusEffect effect = ActiveEffects[i];

            effect.ApplyTurnEffect(this);

            if (!(effect.Type == ElementType.Void)) // For persistant effects
                effect.TurnsRemaining--;

            if (effect.TurnsRemaining <= 0)
            {
                ActiveEffects.RemoveAt(i);
            }
        }
        ApplyAllDebuffs();
    }

    private void ApplyAllDebuffs()
    {
        Damage = BaseDamage;
        Armor = BaseArmor;
        QTESpeed = 1f;

        foreach (StatusEffect effect in ActiveEffects)
        {
            if (effect.Type == ElementType.Poison)
            {
                Damage -= BaseDamage * 0.05f * effect.Stacks;
                Damage = Mathf.Max(Damage, BaseDamage * (1 - effect.MaxDebuff));
            }
            if (effect.Type == ElementType.Corrode)
            {
                Armor -= BaseArmor * 0.05f * effect.Stacks;
                Armor = Mathf.Max(Armor, BaseArmor * (1 - effect.MaxDebuff));
            }
            if (effect.Type == ElementType.Ice)
            {
                QTESpeed = Mathf.Min(QTESpeed, 0.7f);
            }
        }
    }

    public void CheckIfAlive()
    {
        if (Health <= 0 && IsAlive)
        {
            Health = 0;
            IsAlive = false;
            ActiveEffects.Clear();
        }
    }
}
