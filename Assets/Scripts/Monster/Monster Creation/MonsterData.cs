using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterData", menuName = "DeepSanctuary/Monster Data")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public string iconName;
    public DangerLevel dangerLevel;
    public float maxHealth = 100f;
    public float damage = 10f;
}
