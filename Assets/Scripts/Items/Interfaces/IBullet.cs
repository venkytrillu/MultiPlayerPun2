using System.Collections.Generic;
using UnityEngine;

namespace Items.Interfaces
{
    public interface IBullet
    {
        List<Sprite> Bullets { get; }
        Sprite GetBullet();

        void SetBullet();
    }
}