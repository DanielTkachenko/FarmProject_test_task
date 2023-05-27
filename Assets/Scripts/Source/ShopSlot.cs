using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShopSlot : ISlot
    {
        public IItem item { get; private set; }
        public Type itemType => item.itemType;

        public ShopSlot(IItem item)
        {
            this.item = item;
        }
    }
}