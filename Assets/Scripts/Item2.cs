using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Item2 : MonoBehaviour, IItem
{
    [SerializeField] private ItemInfo _itemInfo;
    public IItemInfo itemInfo => _itemInfo;
    public Type itemType => GetType();

    public GameObject parent => gameObject;
        
    public void Action(Game game)
    {
        this.enabled = true;
        Debug.Log("Item 2 action");
        StartCoroutine(ActionCorurine(game));
    }
    
    private IEnumerator ActionCorurine(Game game)
    {
        int counter = 0;
        while (counter < 5)
        {
            counter++;
            game.bank.GetMoney(this, 15);
            yield return new WaitForSeconds(2);
        }
        Destroy(this);
    }
}
