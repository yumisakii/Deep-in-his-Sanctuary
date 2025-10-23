using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterUIInit : MonoBehaviour
{
    [SerializeField] private Image MonsterIcon;
    [SerializeField] private TextMeshProUGUI MonsterName;


    //private string iconName = "Weapon_01";

    public void InitMonster(string monsterName, string monsterIconName, DangerLevel dangerLevel)
    {
        Sprite monsterIcon = Resources.Load<Sprite>("Icons/Monsters/" + monsterIconName);

        MonsterIcon.sprite = monsterIcon;
        MonsterName.text = monsterName;
    }
}
