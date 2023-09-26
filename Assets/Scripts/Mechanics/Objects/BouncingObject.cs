using UnityEngine;

namespace Mechanics.Objects
{
    public abstract class BouncingObject : MonoBehaviour
    {
        public Vector3 FireDir { get; set; }
        public abstract void Bounce(Collision objectHit, Vector3 reflectVector);
    }
}
