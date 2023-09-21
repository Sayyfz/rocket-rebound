using System;
using UnityEngine;

namespace Mechanics.Objects
{
    public class BouncingBullet : BouncingObject 
    {
        [SerializeField] private float speed; 
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            Debug.Log(FireDir);
            _rb.velocity = FireDir * speed ;
        }

        public override void Bounce(Transform bodyHit)
        {
            Vector3 surfaceNormal = bodyHit.up; 

            float angle = Vector3.Angle(surfaceNormal, FireDir);

            Vector3 reflectionDir = Vector3.Reflect(FireDir, surfaceNormal);

            // Rotate the reflection direction by the angle
            reflectionDir = Quaternion.AngleAxis(angle, Vector3.up) * reflectionDir;

            // Update balls direction
            FireDir = reflectionDir;

            // Update rigidbody velocity
            _rb.velocity = FireDir * speed; 
        }

        private void OnCollisionEnter(Collision other)
        {
            Bounce(other.transform);
        }
    }
}
