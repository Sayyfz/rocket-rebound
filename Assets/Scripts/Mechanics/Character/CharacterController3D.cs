using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mechanics.Character
{
    public class CharacterController3D : MonoBehaviour
    {
     
        [SerializeField] private CharacterSpecificSettings settings;
        private PhotonView _pv;
        private CharacterController _controller;
        private Vector3 _moveDir;
        
        private void Awake()
        {
            _pv = GetComponent<PhotonView>();
            if (!_pv.IsMine)
                return;
            _controller = GetComponent<CharacterController>();
        }
        
        private void Update()
        {
            if (!_pv.IsMine)
                return;
            HandleMovement();
            HandleJump();
            HandleGravity();
        }
        private void FixedUpdate()
        {
            if (!_pv.IsMine)
                return;
            _controller.Move(_moveDir * Time.deltaTime);
            
        }
        private void HandleMovement()
        {
            var xzDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized *
                            settings.Speed;
            _moveDir = new Vector3(xzDir.x, _moveDir.y, xzDir.y);
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
