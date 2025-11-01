using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterData", menuName = "DeepSanctuary/Monster Data")]
public class MonsterData : ScriptableObject
{
    public string monsterName = "Default_Monster";
    public string iconName = "";
    public DangerLevel dangerLevel = DangerLevel.Grey;
    public float maxHealth = 100f;
    public float damage = 10f;
    public bool isAlive = true;
}
