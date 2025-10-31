using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Health;


    //private string iconName = "Weapon_01";

    public void InitMonsterUI(string name, string iconName, float health,  DangerLevel dangerLevel)
    {
        Sprite icon = Resources.Load<Sprite>("Icons/Monsters/" + iconName);

        Icon.sprite = icon;
        Name.text = name;
        Health.text = health + "/" + health;
    }
}
