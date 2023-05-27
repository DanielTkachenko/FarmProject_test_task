using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ItemInfo", menuName = "Gameplay/Create New ItemInfo")]
    public class ItemInfo : ScriptableObject, IItemInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private int _price;
        [SerializeField] private Sprite _sprite;
        

        public string id => _id;
        public string title => _title;
        public string description => _description;
        public int price => _price;
        public Sprite sprite => _sprite;
    }
}