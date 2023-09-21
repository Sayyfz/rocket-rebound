using System;
using UnityEngine;

namespace Mechanics.Character
{
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private float minX;
        [SerializeField] private float maxX;

        private float _xRotation;
        private void Update()
        {
            HandleRotation();
        }

        private void HandleRotation()
        {
            // Rotate Player on Mouse Movement
            transform.Rotate(0,Input.GetAxisRaw("Mouse X") ,0);
            // Rotate Player Camera on Mouse Movement
            _xRotation -= Input.GetAxisRaw("Mouse Y");
            _xRotation = Mathf.Clamp(_xRotation, minX, maxX);

            camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            
        }
    }
}