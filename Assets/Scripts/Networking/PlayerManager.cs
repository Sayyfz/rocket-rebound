using System;
using System.IO;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Networking
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        private PhotonView _pv;
        private void Awake()
        {
            _pv = GetComponent<PhotonView>();
            spawnPositions = GameObject.FindWithTag("SpawnPositions").GetComponentsInChildren<Transform>();
        }

        private void Start()
        {
            if (_pv.IsMine)
            {
                SpawnPlayer();
            }
        }

        private void SpawnPlayer()
        {
            
            if (spawnPositions.Length > 0)
            {
                var randomIndex = Random.Range(0, spawnPositions.Length - 1);
                var spawnPos = spawnPositions[randomIndex];
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), spawnPos.position , spawnPos.rotation);
            }
            else
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), Vector3.zero , Quaternion.identity);
            
        }

   
    }
}
