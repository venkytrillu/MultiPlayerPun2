using System;
using System.IO;
using Menus.Interfaces;
using Photon.Pun;
using PlayerScrips;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour, IPlayerManager
    {
        [SerializeField] private SpawnPoints _spawnPoints;
        private PhotonView _photonView;
        private GameObject _playerControllerObj;
       
        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void Start()
        {
            if (_photonView.IsMine)
            {
                CreatePlayerController();
            }
        }

        public PhotonView PhotonView => _photonView;

        public void CreatePlayerController()
        {
            _playerControllerObj = PhotonNetwork.Instantiate(Path.Combine(Helper.PhotonPrefabs, Helper.PlayerController), _spawnPoints.GetRandomLocation().position,
                Quaternion.identity, 0, new object[]{_photonView.ViewID});
        }

        public void Died()
        {
            PhotonNetwork.Destroy(_playerControllerObj);
            CreatePlayerController();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Died();
            }
        }
    }
}