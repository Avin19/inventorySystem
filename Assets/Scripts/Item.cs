using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    [SerializeField] private Image imageSprite;
    [SerializeField] private TextMeshProUGUI quantityText;

    public void SetSprite(Sprite sprite)
    {
        imageSprite.sprite = sprite;
    }
    public void SetQuantityText(int quantity)
    {
        quantityText.text = quantity.ToString();
    }

}