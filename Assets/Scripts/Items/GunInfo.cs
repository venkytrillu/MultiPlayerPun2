using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "FPS/New Gun")]
    public class GunInfo : ItemInfo
    {
        public GunType GunType;
        public int Bullets;
        public float Damage;
        public float Range;
    }
}