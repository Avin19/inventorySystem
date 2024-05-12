using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBarController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText, playerweight, maxWeight;
    [SerializeField] private Button shopBtn, playerInventoryBtn;
    [SerializeField] private MainMenuController mainMenuPanel;
    [SerializeField] private PlayerStatus playerStatus;
    private void Awake()
    {
        shopBtn.onClick.AddListener(OnShopClick);
        playerInventoryBtn.onClick.AddListener(OnPlayerInventorClick);
        UpdateCoinValue(playerStatus.coin);
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
        playerweight.text = "Player Weight: " + playerStatus.playerItemWeight.ToString();
        maxWeight.text = "Player Max Weight: " + playerStatus.maxplayerWeight.ToString();
    }
}
