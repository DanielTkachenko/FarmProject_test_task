using System;

namespace DefaultNamespace
{
    public class InventorySlot : ISlot
    {
        public IItem item { get; private set; }
        public Type itemType => item.itemType;
        public bool isEmpty => item == null;
        public int amount { get; set; } = 0;
        
        public void SetItem(IItem item)
        {
            if(!isEmpty)
                return;
            this.item = item;
        }

        public void Clear()
        {
            if(isEmpty)
                return;
            this.item = null;
            amount = 0;
        }
    }
}