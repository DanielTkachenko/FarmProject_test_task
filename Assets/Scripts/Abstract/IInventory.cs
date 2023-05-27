using System;

namespace DefaultNamespace
{
    public interface IInventory
    {
        InventorySlot activeSlot { get; set; }
        int capacity { get; }
        
        InventorySlot GetSlot(Type itemType);
        int GetItemAmount(Type itemType);

        bool Add(object sender, IItem item, int quantity);
        void Remove(object sender, Type itemType, int amount = 1);
    }
}