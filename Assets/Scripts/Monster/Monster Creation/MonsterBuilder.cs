public static class MonsterBuilder
{
    public static Monster BuildMonster(MonsterData data, int loopNumber)
    {
        float scalingFactor = 1f + (loopNumber * 0.10f); // Scaling here

        Monster newMonster = new Monster
        {
            Name = data.monsterName,
            IconName = data.iconName,
            DangerLevel = data.dangerLevel,
            MaxHealth = data.maxHealth * scalingFactor,
            Damage = data.damage * scalingFactor,
            IsAlive = data.isAlive
        };

        newMonster.Health = newMonster.MaxHealth;

        // 3. (Future Proofing) Add specific level-based features
        // if (loopNumber >= 5) { newMonster.CanDebuff = true; } 

        return newMonster;
    }
}