using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    public InventorySlot slot { get; set; }

    [SerializeField] private UIInventoryItem _item;
    [SerializeField] private Color _selectionColor;
    private Button _button;
    

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OnClickInventorySlot);
    }

    private void OnClickInventorySlot()
    {
        var parentUI = GetComponentInParent<UI>();
        var game = parentUI.GetGame();
        game.SetActiveInventoryItem(slot.item.parent);
        Debug.Log($"[SELECTED ITEM {slot.item.parent.name}]");
    }

    public void Refresh()
    {
        if (slot != null)
        {
            _item.Refresh(slot);
        }
    }
}
