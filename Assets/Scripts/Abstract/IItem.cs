using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public interface IItem
    {
        IItemInfo itemInfo { get; }
        Type itemType { get; }
        
        GameObject parent { get; }
        
        void Action(Game game);
    }
}