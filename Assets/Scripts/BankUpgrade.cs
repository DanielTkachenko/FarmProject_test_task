using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BankUpgrade : MonoBehaviour, IItem
    {
        [SerializeField] private ItemInfo _itemInfo;
        public IItemInfo itemInfo => _itemInfo;
        public Type itemType => GetType();
        
        public GameObject parent => gameObject;


        public void Action(Game game)
        {
            Debug.Log("Bank upgrade action");
            game.bank.IncreaseCapacity(this, 50);
        }
    }
}