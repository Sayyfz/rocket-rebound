using System;
using Core;
using Debugging;
using Mechanics.Objects;
using Photon.Pun;
using UnityEngine;

namespace Mechanics.Character
{
    public class CharacterShoot : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawn;
        [SerializeField] private float totalCooldown;
        [SerializeField] private Transform fpsCamera;
        private float _currentCooldown = 0;
        private PhotonView _pv;

        private void Awake()
        {
            _pv = GetComponent<PhotonView>();
        }

        private void Update()
        {
            if (!_pv.IsMine)
                return;
            _currentCooldown -= Time.deltaTime;
            if (Input.GetButton("Fire1") && _currentCooldown <= 0)
            {
                var bulletPrefab = AssetManager.Instance.bulletGameObj;
                var bulletObj = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.transform.parent.rotation);
                var dir = bulletSpawn.TransformDirection(fpsCamera.forward);
                dir.Normalize();
                bulletObj.GetComponent<BouncingObject>().FireDir = dir;

                
                _currentCooldown = totalCooldown;
            }
        }
    }
}