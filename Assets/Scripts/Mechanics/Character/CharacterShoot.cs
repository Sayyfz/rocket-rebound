using Core;
using Mechanics.Objects;
using UnityEngine;

namespace Mechanics.Character
{
    public class CharacterShoot : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawn;
        [SerializeField] private float totalCooldown;
        [SerializeField] private Transform fpsCamera;
        private float _currentCooldown = 0;

        private void Update()
        {
            _currentCooldown -= Time.deltaTime;
            if (Input.GetButton("Fire1") && _currentCooldown <= 0)
            {
                var bulletPrefab = AssetManager.Instance.bulletGameObj;
                var bulletObj = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.transform.parent.rotation);
                bulletObj.GetComponent<BouncingObject>().FireDir = fpsCamera.forward;
                
                _currentCooldown = totalCooldown;
            }
        }
    }
}