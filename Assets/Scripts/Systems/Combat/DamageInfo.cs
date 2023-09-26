using UnityEngine;

namespace Systems.Combat
{
    public struct DamageInfo 
    {
        public Transform Damager { get; }
        public float Force { get; }
        public float Amount { get; }

        public DamageInfo(float amount,  Transform damager, float force)
        {
            Amount = amount;
            Damager = damager;
            Force = force;
        }

        public DamageInfo(float amount)
        {
            Amount = amount;
            Damager = null;
            Force = 0f;
        }


    }
}
