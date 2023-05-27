using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Inventory : IInventory
    {
        public event Action<object> OnInventoryChangedEvent; 
        public InventorySlot activeSlot { get; set; }
        public int capacity { get; private set; }
        private List<InventorySlot> _slots;

        public Inventory(int capacity)
        {
            this.capacity = capacity;
            _slots = new List<InventorySlot>();
            for (int i = 0; i < this.capacity; i++)
            {
                _slots.Add(new InventorySlot());
            }
        }

        public InventorySlot GetSlot(Type itemType)
        {
            return _slots.Find(slot => slot.itemType == itemType);
        }

        public InventorySlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }

        public int GetItemAmount(Type itemType)
        {
            return _slots.Find(slot => slot.itemType == itemType).amount;
        }

        public bool Add(object sender, IItem item, int quantity = 1)
        {
            var slotWithSameItem = _slots.Find(slot => !slot.isEmpty && slot.itemType == item.itemType);
            if (slotWithSameItem != null)
            {
                slotWithSameItem.amount += quantity;
                OnInventoryChangedEvent?.Invoke(sender);
                return true;
            }

            var emptySlot = _slots.Find(slot => slot.isEmpty);
            if (emptySlot != null)
            {
                emptySlot.SetItem(item);
                emptySlot.amount += quantity;
                Debug.Log(item.parent.name);
                OnInventoryChangedEvent?.Invoke(sender);
                return true;
            }
            Debug.Log("No free place in inventory");
            return false;
        }

        public void Remove(object sender, Type itemType, int amount = 1)
        {
            var neededSlot = GetSlot(itemType);
            if (neededSlot == null)
            {
                Debug.Log("There is no such item in inventory");
                return;
            }

            neededSlot.amount -= amount;
            if(neededSlot.amount <= 0)
                neededSlot.Clear();
            OnInventoryChangedEvent?.Invoke(sender);
        }
    }
}