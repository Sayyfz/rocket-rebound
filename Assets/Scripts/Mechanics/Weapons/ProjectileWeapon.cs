using Core;
using Debugging;
using Mechanics.Objects;
using UnityEngine;

namespace Mechanics.Weapons
{
    public abstract class ProjectileWeapon : Weapon
    {
        [SerializeField] protected Transform projectileSpawn;
        
        public override void Attack()
        {
            var bulletPrefab = AssetManager.Instance.bulletGameObj;
            var bulletObj = Instantiate(bulletPrefab, projectileSpawn.position, projectileSpawn.transform.parent.rotation);
            var dir = projectileSpawn.TransformDirection(fpsCamera.forward);
            dir.Normalize();
            bulletObj.GetComponent<BouncingObject>().FireDir = dir;
        }
    }
}