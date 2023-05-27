using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class UIShopSlot : MonoBehaviour
{
    public ShopSlot slot { get; set; }
    [SerializeField] private UIShopItem _item;
    [SerializeField] private Button _buyButton;

    private void Start()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    public void Refresh()
    {
        if (slot != null)
        {
            _item.Refresh(slot);
        }
    }

    private void OnBuyButtonClick()
    {
        var game = GetComponentInParent<UI>().GetGame();
        var soldItem = slot.item;
        if (game.bank.SpendMoney(this, soldItem.itemInfo.price))
        {
            game.inventory.Add(this, soldItem);
        }
    }
    
}