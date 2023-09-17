using System;
using UnityEngine;
using Photon.Pun;

namespace UI
{
    public class MenuManager : MonoBehaviourPunCallbacks
    {
        public static MenuManager Instance;
        [SerializeField] private Menu[] menus;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
        }

        public override void OnConnectedToMaster() => ToggleMenu("loading");
            
        public void ToggleMenu(string menuName)
        {
            foreach (var menu in menus)
            {
                if (menu.menuName == menuName)
                    OpenMenu(menu);
           
            }
        }

        public void OpenMenu(Menu menu)
        {
            foreach (var m in menus)
            {
                var isMenuOpened = m.gameObject.activeSelf == true;
                if (isMenuOpened)
                    CloseMenu(m);
            }
            menu.Open();
        }
        public void CloseMenu(Menu menu) => menu.Close();
    }
}
