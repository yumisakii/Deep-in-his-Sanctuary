using UnityEngine;

public class StatusEffect
{
    public ElementType Type { get; private set; }
    public int Stacks { get; private set; } = 1;
    public int TurnsRemaining { get; set; } = 2;
    public float BaseDamage { get; private set; } = 10;
    public float SourceDamage { get; private set; } = 10;
    public float MaxDebuff { get; private set; } = 0.30f; // 30%

    public StatusEffect(ElementType type, float baseDamage, int duration)
    {
        Type = type;
        BaseDamage = baseDamage;
        TurnsRemaining = duration;
    }
    public void SetStacks(int amount)
    {
        Stacks = amount;
    }
    public void SetSourceDamage(float amount)
    {
        SourceDamage = amount;
    }

public void ApplyTurnEffect(Monster targetMonster)
    {  
        switch (Type)
        {
            case ElementType.Fire:
                targetMonster.TakeDamage(BaseDamage * Stacks);
                break;

            case ElementType.Poison:
                targetMonster.TakeDamage(BaseDamage);
                // The Poison damage reduction effect is applied in Monster.ApplyAllDebuffs()
                break;

            case ElementType.Ice:
                // The Chill effect is applied in Monster.ApplyAllDebuffs()
                break;

            case ElementType.Bleed:
                float missingHealth = targetMonster.MaxHealth - targetMonster.Health;
                targetMonster.TakeDamage(missingHealth * 0.1f);
                break;

            case ElementType.Lightning:
                float randomRollStun = Random.Range(0f, 1f);
                if (randomRollStun <= 0.05) // 5% chance
                    targetMonster.Damage = 0f;
                break;

            case ElementType.Vampirism:
                PlayerManager.Instance.Player.Heal(SourceDamage);
                break;

            case ElementType.Void:
                if (Stacks >= 10)
                { 
                    targetMonster.TakeDamage(BaseDamage); // If 10 stacks, the monster takes big damages.
                    TurnsRemaining = 0; // We set TurnsRemaining to -100 to make sure that all voids stacks diseapers.
                }
                TurnsRemaining++; // We do that so the voids stacks doesn't diseapear
                break;

            case ElementType.Corrode:
                // The Corride armor reduction effect is applied in Monster.ApplyAllDebuffs()
                break;

            case ElementType.Cull:
                float randomRollCull = Random.Range(0f, 1f);
                if (randomRollCull <= 0.02f)
                    targetMonster.Health = 0f;

                if (targetMonster.Health < targetMonster.MaxHealth * 0.05f)
                    targetMonster.Health = 0f;

                break;

            default:
                break;
        }
    }

    public void AddOneStack()
    {
        Stacks++;
    }

    public void SetTurnRemaining(int turn)
    {
        TurnsRemaining = turn;
    }
}