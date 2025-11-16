public class Player
{
    private float health = 900;
    private float maxHealth = 900;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void Heal(float healValue)
    {
        health += healValue;

        if (health > maxHealth)
            health = maxHealth;
    }
}
