using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ForgeRoomManager : BaseRoomManager
{
    [Header("UI Manager")]
    [SerializeField] private ForgeRoomUIManager uiManager;

    private List<Weapon> currentInventory = new List<Weapon>();

    private Weapon weaponToFuse1 = null;
    private Weapon weaponToFuse2 = null;

    private Weapon fusedWeapon = null;


    public override RoomType Type => RoomType.Forge;

    protected override void OnEnable()
    {
        base.OnEnable();

        currentInventory = Inventory.Instance.GetInventory();

        uiManager.UpdateForgeUI(currentInventory);
    }

    public void SetWeaponsToFuse(Weapon weapon1, Weapon weapon2)
    {
        weaponToFuse1 = weapon1;
        weaponToFuse2 = weapon2;
    }

    public void OnFuse()
    {
        fusedWeapon = WeaponBuilder.FuseWeapons(weaponToFuse1, weaponToFuse2);

        Inventory.Instance.RemoveWeapon(weaponToFuse1);
        Inventory.Instance.RemoveWeapon(weaponToFuse2);

        Inventory.Instance.AddWeapon(fusedWeapon);

        uiManager.InitFusedWeaponSlot(fusedWeapon);
        uiManager.OnFusionButtonClicked();

        StartCoroutine(DelayedGoToNextRoom());
    }

    private IEnumerator DelayedGoToNextRoom()
    {
        yield return new WaitForSeconds(1.0f);
        GoToNextRoom();
    }
}
