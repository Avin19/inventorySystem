using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoBarView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Button shopBtn, playerInventoryBtn, sellBtn, buyBtn;


    public Button ShopButton => shopBtn;
    public Button PlayerInventoryButton => playerInventoryBtn;


}
