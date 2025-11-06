using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Canvas hudCanvas = null;
    [SerializeField] private TextMeshProUGUI healthText = null;

    void Start()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        healthText.text = PlayerManager.Instance.Player.GetHealth() + "/" + PlayerManager.Instance.Player.GetMaxHealth();
    }
}
