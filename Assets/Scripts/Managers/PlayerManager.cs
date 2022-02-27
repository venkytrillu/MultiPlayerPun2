using System;
using System.IO;
using Menus.Interfaces;
using Photon.Pun;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour, IPlayerManager
    {
        private PhotonView _photonView;

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

        public void CreatePlayerController()
        {
            PhotonNetwork.Instantiate(Path.Combine(Helper.PhotonPrefabs, Helper.PlayerController), Vector3.one,
                Quaternion.identity);
        }
    }
}