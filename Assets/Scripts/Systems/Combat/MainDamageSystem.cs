using System;
using System.Collections;
using UnityEngine;

namespace Systems.Combat
{

    public sealed class MainDamageSystem : DamageSystem
    {
        public override event Action<float> OnHealthDown;
        public override event Action<float> OnHealthUp;
        public override event EventHandler OnDead;
        public event Action OnEnemyKilled;
        public override bool GodMode { get; set; }
        public override float CurrentHealth { get; set; }
        public override bool IsDead { get; set; }
        public override float MaxHealth { get => maxHealth; set => maxHealth = value; }

        [SerializeField] private float maxHealth;
        
        #region Event Emitters
        
        public override void TakeDamage(DamageInfo info) => OnDamageTakenHandler(info);
        public override void Heal(float amount) => OnHealthUp?.Invoke(amount);
        public override void Die() => OnDead?.Invoke(this, EventArgs.Empty);
        public void InvokeEnemyKilled() => OnEnemyKilled?.Invoke();
        
        #endregion

        private void Start()
        {
            CurrentHealth = MaxHealth;

            OnHealthUp += OnHealHandler;
            OnDead += OnDeadHandler;
            OnEnemyKilled += OnEnemyKilledHandler;
        }

        #region Event Handlers
 
        private void OnDamageTakenHandler(DamageInfo info)
        {
            if (GodMode)
            {
                
            }
            else
            {
                CurrentHealth -= info.Amount;
                OnHealthDown?.Invoke(info.Amount);
            }   

            if (CurrentHealth > 0)
            {
                // TODO: play take damage effects
            }
            else
                OnDead?.Invoke(this, EventArgs.Empty);

        }

        private void OnHealHandler(float amount)
        {
            CurrentHealth += amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        }
        private void OnEnemyKilledHandler()
        {
            // TODO: play on kill effects
        }
        private void OnDeadHandler(object sender, EventArgs e)
        {
            CurrentHealth = 0;
            IsDead = true;
            // TODO play death effects 
            StartCoroutine(DeathCo());
        }
        #endregion

        private IEnumerator DeathCo()
        {
            yield return new WaitForSeconds(4f);
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }


        


    }


}