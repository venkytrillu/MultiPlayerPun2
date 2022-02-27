using System;
using UnityEngine;

namespace PlayerScrips
{
    public class PlayerGroundCheck : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        private void Awake()
        {
            if (_playerController == null)
            {
                _playerController = GetComponentInParent<PlayerController>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            checkForGrounded(other.gameObject, GroundState.OnGround);
        }

        private void OnTriggerStay(Collider other)
        {
            checkForGrounded(other.gameObject, GroundState.OnGround);
        }

        private void OnTriggerExit(Collider other)
        {
            checkForGrounded(other.gameObject, GroundState.OnAir);
        }

        private void checkForGrounded(GameObject obj, GroundState groundState)
        {
            if (obj.tag.Equals(Helper.Ground))
            {
                _playerController.SetGroundState(groundState);
            }
        }
    }
}