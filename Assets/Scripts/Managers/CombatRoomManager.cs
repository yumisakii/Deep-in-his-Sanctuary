using UnityEngine;

public class CombatRoomManager : MonoBehaviour
{
    [SerializeField] private CombatRoomUIManager uiManager;
    private void Start()
    {
        Weapon newWeapon = new Weapon("Weapon_01", "Red", Rarity.Red);
        Monster newMonster = new Monster("King Skeleton", "Monster_01", DangerLevel.Grey);
        Monster newMonster1 = new Monster("Red Queen", "Monster_03", DangerLevel.Grey);
        Monster newMonster2 = new Monster("Dark Lord", "Monster_02", DangerLevel.Grey);

        uiManager.SetCurrentWeapon(newWeapon);

        uiManager.SetMonsters(newMonster, newMonster1, newMonster2);
    }
}
