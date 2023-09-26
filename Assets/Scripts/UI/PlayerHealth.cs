using System;
using Debugging;
using Systems.Combat;
using UnityEngine;

namespace UI
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private DamageSystem playerDamageSystem;

        private void Start()
        {
            playerDamageSystem.OnHealthDown += OnHealthDownHandler;
            playerDamageSystem.OnHealthUp += OnHealthUpHandler;
            playerDamageSystem.OnDead += OnDeadHandler;
        }

        private void OnHealthDownHandler(float amount)
        {
            CustomLogger.Log($"Health Down by: {amount}");
            
        }
        private void OnHealthUpHandler(float amount)
        {
            CustomLogger.Log($"Health Up by: {amount}");
        }
        private void OnDeadHandler(object sender, EventArgs e)
        {
            CustomLogger.Log("Dead");
        }

        
    }
}