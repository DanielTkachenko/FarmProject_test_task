using UnityEngine;

namespace DefaultNamespace
{
    public interface IItemInfo
    {
        string id { get; }
        string title { get; }
        string description { get; }
        Sprite sprite { get; }
        int price { get; }
    }
}