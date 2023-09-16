using Core;
using UnityEngine;

namespace CharacterMovement
{
    public class CharacterController3D : MonoBehaviour
    {
     
        [SerializeField] private CharacterSpecificSettings settings; 
        
        private CharacterController _controller;
        private Vector3 _moveDir;
        
        private void Awake() => _controller = GetComponent<CharacterController>();
        
        private void Update()
        {
            HandleMovement();
            HandleJump();
            HandleGravity();
        }

      

        private void FixedUpdate()
        {
            _controller.Move(_moveDir * Time.deltaTime);
            
        }
        private void HandleMovement()
        {
            _moveDir.x = Input.GetAxisRaw("Horizontal") * settings.Speed;
            _moveDir.z = Input.GetAxisRaw("Vertical") * settings.Speed;
            
            if (_controller.isGrounded)
                _moveDir.y = -settings.AntiBump;
            
            _moveDir = transform.TransformDirection((_moveDir));
        }
        private void HandleJump()
        {
            if (Input.GetButton("Jump") && _controller.isGrounded) 
                _moveDir.y += settings.AntiBump + settings.JumpForce;
        }
        private void HandleGravity()
        {
            if(!_controller.isGrounded) 
                _moveDir.y -= settings.Gravity * Time.deltaTime;
        }
      
    }
}
