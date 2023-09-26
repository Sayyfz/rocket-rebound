using UnityEngine;

namespace Systems.Combat
{
    public class ForceSystem
    {
        [SerializeField] private Rigidbody rb;

        public void ApplyForce(Vector3 forceToApply)
        {
            rb.AddForce(forceToApply, ForceMode.Impulse);
        }
    }
}