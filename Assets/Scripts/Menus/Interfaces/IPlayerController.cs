using UnityEngine;

namespace Menus.Interfaces
{
    public interface IPlayerController
    {
        float CurrentHealth { get; set; }
        void Jump();
        void Move();
        void Look();
        void Fire();
        void EquipItem(int index);
        void SetGroundState(GroundState groundState);
        void TakeDamage(float damageValue);
        void Died();
    }
}