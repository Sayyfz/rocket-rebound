using Photon.Pun;
using UnityEngine;

namespace Mechanics.Character
{
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private new Transform cameraHolder;
        [SerializeField] private new Transform camera;
        [SerializeField] private float mouseSensitivity, maxX, minX;
        private PhotonView _pv;

        private float _xRotation;

        private void Awake()
        {
            _pv = GetComponent<PhotonView>();
            if(!_pv.IsMine) {
                Destroy(camera.gameObject);
            }
        }

        private void Update()
        {
            if (!_pv.IsMine)
                return;
            HandleRotation();
        }

        private void HandleRotation()
        {
            // Rotate Player on Mouse Movement
            transform.Rotate(0,Input.GetAxisRaw("Mouse X") * mouseSensitivity,0);
            // Rotate Player Camera on Mouse Movement
            _xRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            _xRotation = Mathf.Clamp(_xRotation, minX, maxX);

            cameraHolder.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            
        }
    }
}