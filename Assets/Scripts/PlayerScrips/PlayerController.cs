using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Items;
using Managers;
using Menus.Interfaces;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace PlayerScrips
{
    public class PlayerController : MonoBehaviourPunCallbacks, IPlayerController
    {
        public float CurrentHealth { get; set; } = Helper.MaxHealth;
        [SerializeField] private PlayerUIDisplayData playerUIDisplayData;
        [SerializeField] private List<Item> _items = new List<Item>();
        [SerializeField] private GameObject cameraHolder;
        [SerializeField] private float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
        [SerializeField] private float verticalLookRotation;
        [SerializeField] private bool isGrounded;
        private Vector3 smoothMoveVelocity;
        private Vector3 moveAmount;
        private Rigidbody _rb;
        private PhotonView _photonView;
        private PlayerManager _playerManager;

        private int _currentItemIndex;
        private int _previousItemIndex = -1;
        
        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            _rb = GetComponent<Rigidbody>();
            _playerManager = PhotonView.Find((int) _photonView.InstantiationData[0]).GetComponent<PlayerManager>();
            playerUIDisplayData.SetUp(_playerManager.PhotonView); 
        }

        private void Start()
        {
            if (!_photonView.IsMine)
            {
                Destroy(GetComponentInChildren<Camera>().gameObject);
                Destroy(GetComponent<Rigidbody>());
                playerUIDisplayData.SetPlayerName(_photonView.Owner.NickName);
                playerUIDisplayData.DestroyPlayerHealth();
            }
            else
            {
                EquipItem(0);
                playerUIDisplayData.DestroyName();
            }
        }

        private void Update()
        {
            if (!_photonView.IsMine)
                return;

            Look();
            Move();
            Jump();
            Fire();
            changeWeapons();
        }

        private void FixedUpdate()
        {
            if (!_photonView.IsMine)
                return;

            _rb.MovePosition(_rb.position + (transform.TransformDirection(moveAmount) * Time.fixedDeltaTime));
        }

        

        public void Jump()
        {
            if (InputManager.Instance.IsJump && isGrounded)
            {
                _rb.AddForce(transform.up * jumpForce);
            }
        }

        public void Move()
        {
            Vector3 moveDir =
                new Vector3(InputManager.Instance.GetAxisHorizontal, 0, InputManager.Instance.GetAxiVertical)
                    .normalized;

            moveAmount = Vector3.SmoothDamp(moveAmount,
                moveDir * (InputManager.Instance.IsSprint ? sprintSpeed : walkSpeed),
                ref smoothMoveVelocity, smoothTime);
        }

        public void Look()
        {
            transform.Rotate(Vector3.up * (InputManager.Instance.GetAxisMouseX * mouseSensitivity));

            verticalLookRotation += (InputManager.Instance.GetAxisMouseY * mouseSensitivity);
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
        }

        private void changeWeapons()
        {
            if (Input.GetKeyDown("0") || Input.GetKeyDown("1"))
            {
                if (Input.GetKeyDown("0"))
                {
                    EquipItem(0);
                }
                else if (Input.GetKeyDown("1"))
                {
                    EquipItem(1);
                }
            }

            if (InputManager.Instance.GetAxisMouseScrollWheel > 0f)
            {
                if (_currentItemIndex >= _items.Count - 1)
                {
                    EquipItem(0);
                }
                else
                {
                    EquipItem(_currentItemIndex + 1);
                }
            }
            else if (InputManager.Instance.GetAxisMouseScrollWheel < 0f)
            {
                if (_currentItemIndex <= 0)
                {
                    EquipItem(_items.Count - 1);
                }
                else
                {
                    EquipItem(_currentItemIndex - 1);
                }
            }
        }

        public void Fire()
        {
            if(InputManager.Instance.IsSingleShoot)
            {
                if (_items.Count > 0)
                {
                    _items[_currentItemIndex].Use();
                }
            }
            
            if(InputManager.Instance.IsRifleShoot)
            {
                if (_items.Count > 0 && ((GunInfo)_items[_currentItemIndex].ItemInfo).GunType == GunType.Rifle)
                {
                    _items[_currentItemIndex].Use();
                }
            }
        }

        public void EquipItem(int index)
        {
            if (_previousItemIndex == index)
                return;

            _currentItemIndex = index;

            _items[_currentItemIndex].IsActive = true;

            if (_previousItemIndex != -1)
            {
                _items[_previousItemIndex].IsActive = false;
            }

            _previousItemIndex = _currentItemIndex;

            updatePlayerData();
        }

        private void updatePlayerData()
        {
            if (_photonView.IsMine)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add(Helper.ItemIndex, _currentItemIndex);
                PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
            }
        }

        public void SetGroundState(GroundState groundState)
        {
            switch (groundState)
            {
                case GroundState.OnGround:
                    isGrounded = true;
                    break;

                case GroundState.OnAir:
                    isGrounded = false;
                    break;

                default:
                    isGrounded = true;
                    break;
            }
        }
        
        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (!_photonView.IsMine && targetPlayer == _photonView.Owner)
            {
                EquipItem((int) changedProps[Helper.ItemIndex]);
            }
        }

        public void TakeDamage(float damageValue)
        {
            _photonView.RPC("RPC_TakeDamage", RpcTarget.All, damageValue);
        }
        

        [PunRPC] 
        void RPC_TakeDamage(float damage)
        {
            if (!_photonView.IsMine)
            {
                return;
            }

            CurrentHealth -= damage;
            playerUIDisplayData.SetHealth(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                Died();
            }
        }

        public void Died()
        {
            _playerManager.Died();
        }
    }
}