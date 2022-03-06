using System;
using Menus.Interfaces;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;

namespace Items.Guns
{
    public class SingleShotGun : Gun
    {
        [SerializeField] private Camera _camera;

        private PhotonView _photonView;
        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();

            if (_photonView == null)
            {
                Debug.Log("_photonView == null ");
            }
        }

        public override void Use()
        {
            shoot();
        }

        private void shoot()
        {
            Vector3 rayOrigin = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            if (Physics.Raycast(rayOrigin, _camera.transform.forward, out RaycastHit raycastHit, GunInfo.Range))
            {
                Debug.Log(raycastHit.collider.gameObject.name);
                //Debug.DrawRay(rayOrigin, raycastHit.point, Color.yellow);
                var playerController = raycastHit.collider.gameObject.GetComponentInParent<IPlayerController>();
                if (playerController != null)
                {
                    raycastHit.collider.gameObject.GetComponentInParent<IPlayerController>().TakeDamage(GunInfo.Damage);
                }
                _photonView.RPC("RPC_Shoot", RpcTarget.All, raycastHit.point, raycastHit.normal);
            }
        }

        [PunRPC]
        private void RPC_Shoot(Vector3 hitPos, Vector3 hitNormal)
        {
            Collider[] colliders = Physics.OverlapSphere(hitPos, 0.3f);

            if (colliders.Length > 0)
            {
             GameObject bulletPrefab = Instantiate(BulletImpactPrefab, hitPos + hitNormal * 0.001f, 
                    Quaternion.LookRotation(hitNormal, Vector3.up) * BulletImpactPrefab.transform.rotation);
             bulletPrefab.transform.SetParent(colliders[0].transform);
            }
            
        }
    }
}