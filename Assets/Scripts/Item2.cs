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
        var timer = 0f;
        int counter = 0;
        while (counter < 5)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                timer = 0;
                counter++;
                game.bank.GetMoney(this, 15);
            }

            yield return new WaitForEndOfFrame();
        }
        Destroy(this);
    }
}
