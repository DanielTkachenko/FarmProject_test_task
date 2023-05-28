using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    public Bank bank;
    public Inventory inventory;
    public Shop shop;
    [SerializeField] private GameObject[] itemsInShop;
    private GameObject _activeInventoryItem;
    private void Awake()
    {
        List<IItem> items = new List<IItem>();
        foreach (var item in itemsInShop)
        {
            items.Add(item.GetComponent<IItem>());
        }
        shop = new Shop(items.ToArray());
        inventory = new Inventory(4);
        bank = new Bank();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.gameObject.layer != 5)
            {
                var hitPoint = hitInfo.point;
                if (_activeInventoryItem != null)
                {
                    PlaceObject(hitPoint);
                } 
                else
                    Debug.Log("To items of that type");
            }
        }
    }

    private void PlaceObject(Vector3 position)
    {
        Debug.Log("hello");
        IItem item = _activeInventoryItem.GetComponent<IItem>();
        Instantiate(_activeInventoryItem, position, Quaternion.identity);
        item.Action(this);
        if (inventory.GetItemAmount(item.itemType) > 1)
        {
            inventory.Remove(this, item.itemType);
        }
        else
        {
            inventory.Remove(this, item.itemType);
            _activeInventoryItem = null;
        }
        
    }

    public void SetActiveInventoryItem(GameObject newItem)
    {
        _activeInventoryItem = newItem;
    }
}
