using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Text _amountText;


    public void Refresh(InventorySlot slot)
    {
        if (slot.isEmpty)
        {
            _itemIcon.gameObject.SetActive(false);
            _amountText.gameObject.SetActive(false);
            return;
        }

        _itemIcon.sprite = slot.item.itemInfo.sprite;
        _itemIcon.gameObject.SetActive(true);

        var textAmountEnabled = slot.amount > 1;
        _amountText.gameObject.SetActive(textAmountEnabled);
        if (textAmountEnabled)
            _amountText.text = $"x{slot.amount}";
    }
}