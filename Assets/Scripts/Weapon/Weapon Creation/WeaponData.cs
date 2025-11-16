using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "DeepSanctuary/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName = "defaultWeapon";
    public float damage = 10f;
    public string weaponIconName = "";
    public string spellIconName = "";
    public Tiers tier = Tiers.Gray;
    public ElementType element = ElementType.None;
    public Skill skill = new Skill();
}