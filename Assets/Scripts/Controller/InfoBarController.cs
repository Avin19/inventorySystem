
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBarController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Button shopBtn, playerInventoryBtn;
    [SerializeField] private MainMenuController mainMenuPanel;
    private void Awake()
    {
        shopBtn.onClick.AddListener(OnShopClick);
        playerInventoryBtn.onClick.AddListener(OnPlayerInventorClick);
    }

    private void OnShopClick()
    {
        mainMenuPanel.ShopOpen();
    }

    private void OnPlayerInventorClick()
    {
        mainMenuPanel.PlayerOpen();
    }

    public void UpdateCoinValue(int coin)
    {
        coinText.text = coin.ToString();
    }
}
