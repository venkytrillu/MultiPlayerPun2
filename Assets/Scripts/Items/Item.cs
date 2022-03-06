using PlayerScrips.Interfaces;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour, IItem
    {
        [SerializeField] private ItemInfo _itemInfo;
        [SerializeField] private GameObject _item;
        public GameObject ItemObject => _item;
        public bool IsActive
        {
            get => _item.activeSelf;
            set => _item.SetActive(value);
        }

        public ItemInfo ItemInfo => _itemInfo;
        public abstract void Use();
    }
}