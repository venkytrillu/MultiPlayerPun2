using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScrips
{
    public class PlayerUIDisplayData : MonoBehaviour
    {
        [SerializeField] private Image _playerHealthBar;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private GameObject _playerNameContainer;
        [SerializeField] private TMP_Text _playerNameText;

        private Camera _camera;
        private PhotonView _photonView;
        private void Awake()
        {
            SetHealth(Helper.MaxHealth);
        }

        public void SetUp(PhotonView photonView)
        {
            _photonView = photonView;
        }
        
        public void SetHealth(float damageValue)
        {
            _playerHealthBar.fillAmount = damageValue / Helper.MaxHealth;
            _healthText.text = damageValue.ToString() +"%";
        }
        
        public void SetPlayerName(string name)
        {
            _playerNameText.text = name;
        }

        public void DestroyPlayerHealth()
        {
            Destroy(_playerHealthBar.gameObject);
        }
        
        public void DestroyName()
        {
            Destroy(_playerNameContainer);
        }

        private void Update()
        {
            if (_playerNameContainer == null )
            {
                return;
            }
            
            if (_camera == null)
            {
                _camera = FindObjectOfType<Camera>();
            }

            if (_camera == null)
            {
                return;
            }
            _playerNameContainer.transform.LookAt(_camera.transform.parent);
            _playerNameContainer.transform.Rotate(Vector3.up * 180);
        }
    }
}
