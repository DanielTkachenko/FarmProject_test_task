using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private UIInventorySlot[] _uiInventorySlots;
    public Inventory inventory { get; private set; }

    private void Start()
    {
        
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnInventoryChangedEvent += Refresh;
        _uiInventorySlots = GetComponentsInChildren<UIInventorySlot>();
        var allSlots = this.inventory.GetAllSlots();
        for (int i = 0; i < allSlots.Length; i++)
        {
            _uiInventorySlots[i].slot = allSlots[i];
            _uiInventorySlots[i].Refresh();
        }
        
    }

    public void SetSelected(UIInventorySlot slot)
    {
        foreach (var s in _uiInventorySlots)
        {
            s.SetSelected(false);
        }
        slot.SetSelected(true);
    }

    public void Refresh(object sender)
    {
        foreach (var slot in _uiInventorySlots)
        {
            slot.Refresh();
        }
    }
}