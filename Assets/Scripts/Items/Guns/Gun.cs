using UnityEngine;

namespace Items.Guns
{
    public abstract class Gun : Item
    {
        [SerializeField] protected GameObject BulletImpactPrefab;
        public GunInfo GunInfo => (GunInfo)ItemInfo;
        public abstract override void Use();
        
    }
}