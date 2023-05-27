using System;

namespace DefaultNamespace
{
    public interface ISlot
    {
        public IItem item { get; }
        public Type itemType { get; }
    }
}