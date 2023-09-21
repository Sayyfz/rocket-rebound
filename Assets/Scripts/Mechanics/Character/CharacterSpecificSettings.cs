using System;
using UnityEngine;

namespace Mechanics.Character
{
    public class CharacterSpecificSettings : MonoBehaviour
    {
        [SerializeField] private float speed = 15f;
        [SerializeField] private float gravity = 9.8f;
        [SerializeField] private float antiBump = 2f;
        [SerializeField] private float jumpForce = 10f;
        
        public float Speed { get => speed; private set => speed = value; }
        public float Gravity { get => gravity; private set => gravity = value; }
        public float AntiBump {get => antiBump; private set => antiBump = value; }
        public float JumpForce { get => jumpForce; private set => jumpForce = value; }

    }
}