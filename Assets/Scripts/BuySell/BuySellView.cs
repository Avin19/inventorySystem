using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyCellView : MonoBehaviour
{
    [SerializeField] private Button okBtn, cancelBtn, addQuantityBtn, removeQuantityBtn;
    [SerializeField] private TextMeshProUGUI quantityText, titleText;

    public Button OkButton => okBtn;
    public Button CancelButton => cancelBtn;
    public Button AddQuantityButton => addQuantityBtn;
    public Button RemoveQuantityButton => removeQuantityBtn;
    public TextMeshProUGUI QuantityText => quantityText;
    public TextMeshProUGUI TitleText => titleText;

    private void Awake()
    {
        BuySellController buySellController = new BuySellController(this);
    }

}
