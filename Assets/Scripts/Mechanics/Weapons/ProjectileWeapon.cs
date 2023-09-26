using System.IO;
using Mechanics.Objects;
using Photon.Pun;
using UnityEngine;

namespace Mechanics.Weapons
{
    public abstract class ProjectileWeapon : Weapon
    {
        [SerializeField] protected Transform projectileSpawn;
        [SerializeField] private Camera mainCam;
        
        public override void Attack()
        {
            var bulletObj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BouncingBullet"), projectileSpawn.position, Quaternion.identity);
            var x = Screen.width / 2f;
            var y = Screen.height / 2f;

            var ray = mainCam.ScreenPointToRay(new Vector3(x, y, 0));
            
            var lookRotation = Quaternion.LookRotation(ray.direction);
            bulletObj.transform.rotation = lookRotation;

            var dir = ray.direction;
            bulletObj.GetComponent<BouncingObject>().FireDir = dir;

        }
    }
}