using UnityEngine;

namespace Mechanics.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private float totalCooldown = 1f;
        [SerializeField] protected Transform fpsCamera;
        
        public float TotalCooldown { get => totalCooldown; set => totalCooldown = value; }

        public abstract void Attack();

    }
}