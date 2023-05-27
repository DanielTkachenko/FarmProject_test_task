using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private UIInventory _uiInventory;
    [SerializeField] private UIShop _uiShop;
    [SerializeField] private Game _game;
    [SerializeField] private Button _shopButton;
    [SerializeField] private UIInfo _uiInfo;

    private void Start()
    {
        //_game = new Game();
        SetupUI(_game.inventory, _game.shop);
        _shopButton.onClick.AddListener(OnShopButtonClick);
        _uiInfo.Refresh(this, _game.bank.coins, _game.bank.capacity);
        _game.bank.OnCoinsValueChangedEvent += _uiInfo.Refresh;
    }

    private void OnShopButtonClick()
    {
        if(_uiShop.gameObject.activeSelf)
            _uiShop.gameObject.SetActive(false);
        else
            _uiShop.gameObject.SetActive(true);
    }

    public void SetupUI(Inventory inventory, Shop shop)
    {
        _uiInventory.SetInventory(inventory);
        _uiShop.SetShop(shop);
    }

    public Game GetGame()
    {
        return _game;
    }
}
