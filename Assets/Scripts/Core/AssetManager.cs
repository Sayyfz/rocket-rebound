using UnityEngine;

namespace Core
{
    public class AssetManager : MonoBehaviour
    {
        public GameObject bulletGameObj;
        
        public static AssetManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this) 
                Destroy(this); 
            else 
                Instance = this; 
        }
    }
}
