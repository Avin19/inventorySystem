using System;
using System.Collections.Generic;
using UnityEngine;


public class TabController
{
    private ShopTabView shopTabView;

    private GameObject pfItem;
    private RectTransform itemHolder;


    public TabController(ShopTabView shopTabView, GameObject pfItem, RectTransform itemHolder)
    {
        this.shopTabView = shopTabView;

        this.pfItem = pfItem;
        this.itemHolder = itemHolder;
        shopTabView.MaterialButton.onClick.AddListener(OnMaterialButtonClick);

    }

    private void OnMaterialButtonClick()
    {

    }





}
