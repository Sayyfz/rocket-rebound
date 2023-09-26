using System;
using Systems.Combat;
using UnityEngine;
namespace Systems.Combat
{

    public abstract class DamageSystem : MonoBehaviour
    {
        public abstract bool GodMode { get; set; }
        public abstract float MaxHealth { get; set; }
        public abstract bool IsDead { get; set; }
        public abstract float CurrentHealth { get; set; }
        
        public abstract event Action<float> OnHealthDown;
        public abstract event Action<float> OnHealthUp;
        public abstract event EventHandler OnDead;
        public abstract void TakeDamage(DamageInfo info);
        public abstract void Heal(float amount);
        public abstract void Die();
    }


}