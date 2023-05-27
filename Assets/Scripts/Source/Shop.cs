using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace
{
    public class Shop
    {
        private List<ShopSlot> _slots;
        public int capacity { get; private set; }

        public Shop(IItem[] items)
        {
            this.capacity = items.Length;
            _slots = new List<ShopSlot>();
            for (int i = 0; i < capacity; i++)
            {
                _slots.Add(new ShopSlot(items[i]));
            }
        }

        public IItem GetItem(object sender, Type itemType)
        {
            return _slots.Find(slot => slot.itemType == itemType).item;
        }

        public ShopSlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }
    }
}