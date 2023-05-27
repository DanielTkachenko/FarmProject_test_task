using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [SerializeField] private Text _titleText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Text _priceText;

    public void Refresh(ShopSlot slot)
    {
        _titleText.text = slot.item.itemInfo.title;
        _iconImage.sprite = slot.item.itemInfo.sprite;
        _priceText.text = slot.item.itemInfo.price.ToString();
    }
}