using UnityEngine;

[CreateAssetMenu(fileName = "NewStatusEffectData", menuName = "DeepSanctuary/StatusEffect Data")]
public class StatusEffectData : ScriptableObject
{
    public ElementType Type = ElementType.None;
    public int Stacks = 1;
    public int TurnsRemaining = 1;
    public float Damage = 10;
    public float MaxDebuff = 0.30f; // 30%
}