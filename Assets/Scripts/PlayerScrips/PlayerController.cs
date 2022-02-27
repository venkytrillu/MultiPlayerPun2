using System;
using Menus.Interfaces;
using Photon.Pun;
using UnityEngine;

namespace PlayerScrips
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] private GameObject cameraHolder;
        [SerializeField] private float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
        [SerializeField] private float verticalLookRotation;
        [SerializeField] private bool isGrounded;
        private Vector3 smoothMoveVelocity;
        private Vector3 moveAmount;
        private Rigidbody _rb;
        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (!_photonView.IsMine)
            {
                Destroy(GetComponentInChildren<Camera>().gameObject);
                Destroy(GetComponent<Rigidbody>());
            }
        }

        private void Update()
        {
            if (!_photonView.IsMine)
                return;
            
            Look();
            Move();
            Jump();
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

        public void SetGroundState(GroundState groundState)
        {
            switch (groundState)
            {
                case GroundState.OnGround:
                    isGrounded = true;
                    break;
                
                case GroundState.OnAir :
                    isGrounded = false;
                    break;
                
               default:
                   isGrounded = true;
                    break;
                
            }
            
        }
    }
}