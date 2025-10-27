using System.Collections.Generic;
using UnityEngine;

public class CombatRoomManager : BaseRoomManager
{
    [SerializeField] private CombatRoomUIManager uiManager;

    private Monster randomMonster0 = null;
    private Monster randomMonster1 = null;
    private Monster randomMonster2 = null;

    protected override void OnEnable()
    {
        base.OnEnable();

        AllMonsters.InitAllMonsters();

        Weapon newWeapon = new Weapon("Weapon_01", "Red", Rarity.Red);

        uiManager.SetCurrentWeapon(newWeapon);


        List<Monster> monsters = AllMonsters.GetCopieAllMonsters();

        randomMonster0 = UsefulFunctions.GetRandomElementAndDelete(monsters);
        randomMonster1 = UsefulFunctions.GetRandomElementAndDelete(monsters);
        randomMonster2 = UsefulFunctions.GetRandomElementAndDelete(monsters);

        uiManager.SetMonsters(randomMonster0, randomMonster1, randomMonster2);
    }
}
