using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Item : MonoBehaviour, IItem
    {
        [SerializeField] private ItemInfo _itemInfo;
        public IItemInfo itemInfo => _itemInfo;
        public Type itemType => GetType();

        public GameObject parent => gameObject;

        private bool state = true;

        public void Action(Game game)
        {
            this.enabled = true;
            Debug.Log("Item action");
            StartCoroutine(ActionCorurine(game));
        }

        private IEnumerator ActionCorurine(Game game)
        {
            int counter = 0;
            while (counter < 3)
            {
                counter++;
                game.bank.GetMoney(this, 10);
                yield return new WaitForSeconds(2);
            }
            Destroy(this);
        }
    }
}