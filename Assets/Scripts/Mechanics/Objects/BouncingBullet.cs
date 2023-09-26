using Photon.Pun;
using UnityEngine;

namespace Mechanics.Objects
{
    public class BouncingBullet : BouncingObject 
    {
        [SerializeField] private float speed;
        [SerializeField] private const float totalTimeToDie = 4f;
        [SerializeField] private LayerMask bouncingMask;
        [SerializeField] private LayerMask pLayerMask;
        private Rigidbody _rb;
        private PhotonView _pv;
        private float _timerToDie;

        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _pv = GetComponent<PhotonView>();
            _rb.velocity = FireDir * speed ;
            ResetTimer();
        }

        private void Update()
        {
            if (!_pv.IsMine) return;
            if(_timerToDie <= 0)
                PhotonNetwork.Destroy(gameObject);
            _timerToDie -= Time.deltaTime;
        }

        public override void Bounce(Collision objectHit, Vector3 reflectVector)
        {
            _rb.velocity = Vector3.Reflect(-objectHit.relativeVelocity, reflectVector);
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (!_pv.IsMine) return;
            // Hit Bouncing Wall
            if ((bouncingMask & (1 << other.gameObject.layer)) != 0)
            {
                Bounce(other, other.contacts[0].normal);
                ResetTimer();
                return;
            }
            // Hit Any Player Including Self
            if ((pLayerMask & (1 << other.gameObject.layer)) != 0)
            {
                var playerPv = other.gameObject.GetComponentInParent<PhotonView>();
                if (playerPv.IsMine) return;
            }
            // Hit Anything Else
            PhotonNetwork.Destroy(gameObject);
            // Play Bullet Destroy Effect
        }

        private void ResetTimer() => _timerToDie = totalTimeToDie;
    }
}
