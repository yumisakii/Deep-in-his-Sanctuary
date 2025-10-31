public static class MonsterBuilder
{
    // LoopNumber represents how many times the player has beaten the Boss Room.
    public static Monster BuildMonster(MonsterData data, int loopNumber)
    {
        // Calculate a scaling factor (e.g., 10% more stats per loop)
        float scalingFactor = 1f + (loopNumber * 0.10f);

        // 1. Create the base Monster object
        Monster newMonster = new Monster
        {
            Name = data.monsterName,
            IconName = data.iconName,
            DangerLevel = data.dangerLevel,
            MaxHealth = data.maxHealth * scalingFactor, // Apply scaling
            Damage = data.damage * scalingFactor,       // Apply scaling
        };

        // 2. Set current Health based on the scaled MaxHealth
        newMonster.Health = newMonster.MaxHealth;

        // 3. (Future Proofing) Add specific level-based features
        // if (loopNumber >= 5) { newMonster.CanDebuff = true; } 

        return newMonster;
    }
}