using Networking;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI
{
    public class RoomListItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private RoomInfo _info;
        public void Setup(RoomInfo info)
        {
            _info = info;
            text.text = info.Name;
        }

        public void OnClick()
        {
            Launcher.Instance.JoinRoom(_info);
        }
    }
}
