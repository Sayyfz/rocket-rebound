using Mechanics.Weapons;
using Photon.Pun;
using UnityEngine;

namespace Mechanics.Character
{
    public class CharacterWeaponManager : MonoBehaviour
    {
        private PhotonView _pv;
        private Weapon[] _weaponInventory;
        private int _currentWeaponIndex;
        private float _currentCooldown;

        private void Awake()
        {
            _weaponInventory = GetComponentsInChildren<Weapon>(true);
            EquipWeapon(0);
            _pv = GetComponent<PhotonView>();
        }
    
        private void Update()
        {
            if (!_pv.IsMine)
                return;

            HandleWeaponAttack();
            HandleWeaponSwitching();

        }

        private void HandleWeaponSwitching()
        {
            for (var i = 0; i < _weaponInventory.Length; i++)
            {
                if (!Input.GetKeyDown((i + 1).ToString())) continue;
                EquipWeapon(i);
                break;
            }

            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
            {
                var nextWeaponIndex = _currentWeaponIndex + 1;
                EquipWeapon(nextWeaponIndex > _weaponInventory.Length - 1 ? 0 : nextWeaponIndex);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
            {
                var prevWeaponIndex = _currentWeaponIndex - 1;
                EquipWeapon(prevWeaponIndex < 0 ?  _weaponInventory.Length - 1 : prevWeaponIndex);
            }
        }

        private void HandleWeaponAttack()
        {
            _currentCooldown -= Time.deltaTime;
            if (Input.GetButtonDown("Fire1") && _currentCooldown <= 0)
            {
                _weaponInventory[_currentWeaponIndex].Attack();
                _currentCooldown = _weaponInventory[_currentWeaponIndex].TotalCooldown;
            }
        }

        private void EquipWeapon(int newWeaponIndex)
        {
            
            var currentWeapon = _weaponInventory[_currentWeaponIndex];
            if(currentWeapon)
                currentWeapon.gameObject.SetActive(false);
            _weaponInventory[newWeaponIndex].gameObject.SetActive(true);
            
            _currentWeaponIndex = newWeaponIndex;
            
        }
    }
}