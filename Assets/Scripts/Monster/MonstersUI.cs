using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour
{
    [SerializeField] private CombatRoomManager combatRoomManager;

    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Health;

    private Monster monster = null;
    

    public void InitMonsterUI(Monster newMonster)
    {
        monster = newMonster;

        Sprite icon = Resources.Load<Sprite>("Icons/Monsters/" + monster.IconName);

        Icon.sprite = icon;
        Name.text = monster.Name;
        Health.text = monster.Health + "/" + monster.MaxHealth;
    }

    public void UpdateMonsterUI()
    {
        Health.text = monster.Health + "/" + monster.MaxHealth;
    }

    public void isAttacked()
    {
        combatRoomManager.AttackMonster(monster);
    }
}
