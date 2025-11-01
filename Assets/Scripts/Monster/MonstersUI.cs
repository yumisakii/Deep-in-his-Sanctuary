using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour
{
    [SerializeField] private CombatRoomManager combatRoomManager;

    [SerializeField] private Image Icon = null;
    [SerializeField] private Image DeathIcon = null;
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private TextMeshProUGUI Health = null;
    [SerializeField] private Button Button = null;

    private Monster monster = null;
    

    public void InitMonsterUI(Monster newMonster)
    {
        monster = newMonster;

        Sprite icon = Resources.Load<Sprite>("Icons/Monsters/" + monster.IconName);

        Icon.color = new Color32(255, 255, 255, 255);
        Icon.sprite = icon;
        Name.text = monster.Name;
        Health.text = monster.Health + "/" + monster.MaxHealth;
        DeathIcon.enabled = false;
        Button.interactable = false;
    }

    public void UpdateMonsterUI()
    {
        Health.text = monster.Health + "/" + monster.MaxHealth;
    }

    public void SetButtonInteractable(bool isInteractable)
    {
        Button.interactable = isInteractable;
    }

    public void isAttacked()
    {
        combatRoomManager.AttackMonster(monster);
    }

    public void isDead()
    {
        monster.Health = 0;
        Icon.color = new Color32(65, 65, 65, 255);
        DeathIcon.enabled = true;
        Button.interactable = false;
    }

    public Monster GetMonster()
    {
        return monster;
    }
}
