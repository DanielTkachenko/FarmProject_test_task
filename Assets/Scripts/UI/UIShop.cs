using System;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    
    private UIShopSlot[] _uiShopSlots;
    public Shop shop { get; private set; }
    
    public void SetShop(Shop shop)
    {
        this.shop = shop;
        _uiShopSlots = GetComponentsInChildren<UIShopSlot>();
        var allSlots = this.shop.GetAllSlots();
        for (int i = 0; i < allSlots.Length; i++)
        {
            _uiShopSlots[i].slot = allSlots[i];
            _uiShopSlots[i].Refresh();
        }
    }

    public void Refresh()
    {
        foreach (var slot in _uiShopSlots)
        {
            slot.Refresh();
        }
    }
}