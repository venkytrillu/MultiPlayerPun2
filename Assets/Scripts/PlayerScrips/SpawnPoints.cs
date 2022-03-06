using System.Collections.Generic;
using UnityEngine;

namespace PlayerScrips
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPointsList = new List<Transform>();

        public Transform GetRandomLocation()
        {
            return _spawnPointsList[Random.Range(0, _spawnPointsList.Count - 1)];
        }
    }
}
