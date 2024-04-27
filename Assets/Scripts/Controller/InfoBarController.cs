using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBarController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    public void UpdateCoinValue(int coin)
    {
        coinText.text = coin.ToString();
    }
}
