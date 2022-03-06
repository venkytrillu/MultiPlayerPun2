using System;
using UnityEngine;

namespace Items
{
    public class DestroyItem : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 2);
        }
    }
}