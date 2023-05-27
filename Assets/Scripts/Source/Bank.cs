using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bank
    {
        public event Action<object, int, int> OnCoinsValueChangedEvent;
        public bool isFull => coins == capacity;
        public int coins { get; private set; }
        public int capacity { get; private set; }

        public Bank()
        {
            coins = 100;
            capacity = 100;
        }
        
        

        public void GetMoney(object sender,int amount)
        {
            if (this.coins + amount >= capacity)
                this.coins = capacity;
            else
                this.coins += amount;
            
            this.OnCoinsValueChangedEvent?.Invoke(sender, this.coins, this.capacity);
        }

        public bool SpendMoney(object sender,int amount)
        {
            if (IsEnoughMoney(amount))
            {
                this.coins -= amount;
                this.OnCoinsValueChangedEvent?.Invoke(sender, this.coins, this.capacity);
                return true;
            }

            return false;
        }

        public bool IsEnoughMoney(int amount)
        {
            return this.coins >= amount;
        }

        public void IncreaseCapacity(object sender,int addedCapacity)
        {
            capacity += addedCapacity;
            
            this.OnCoinsValueChangedEvent?.Invoke(sender, this.coins, this.capacity);
        }
    }
}