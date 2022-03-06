using Items;
using UnityEngine;

namespace PlayerScrips.Interfaces
{
    public interface IItem
    {
        ItemInfo ItemInfo { get; }
        void Use();
        GameObject ItemObject { get; }
        bool IsActive { get; set; }
    }
}