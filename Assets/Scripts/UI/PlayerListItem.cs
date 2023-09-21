using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI
{
   public class PlayerListItem : MonoBehaviourPunCallbacks
   {
      [SerializeField] private TMP_Text text;
      private Player _player;
      public void Setup(Player player)
      {
         _player = player;
         text.text = _player.NickName;
      
      }

      public override void OnPlayerLeftRoom(Player playerLeft)
      {
         Debug.Log("player left");
         if (_player == playerLeft)
         {
            Destroy(gameObject);
         }
      }

      public override void OnLeftRoom()
      {
         Destroy(gameObject);
         MenuManager.Instance.ToggleMenu("title");
         // TODO Make another event and fire it on playerLeft and their object is destroyed
         // MenuManager.Instance.ToggleMenu("loading");
      }
   }
}
