using UnityEngine;

public class CombatRoomManager : MonoBehaviour
{
    [SerializeField] private CombatRoomUIManager uiManager;
    void Start()
    {
        Weapon newWeapon = new Weapon("Weapon_01", "Red", Rarity.Red);

        uiManager.SetCurrentWeapon(newWeapon);
    }


    void Update()
    {
        
    }
}
