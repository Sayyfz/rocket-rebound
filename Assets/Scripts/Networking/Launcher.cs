using Photon.Pun;
using UI;
using UnityEngine;
using TMPro;

namespace Networking
{
    public class Launcher : MonoBehaviourPunCallbacks
    {

        [SerializeField] private TMP_InputField roomNameInput;
        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }   
        // Called when connected to the server
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            MenuManager.Instance.ToggleMenu("title");
            Debug.Log("Joined lobby");
        }

        public void CreateRoom()
        {
            if (string.IsNullOrEmpty(roomNameInput.text))
                return;
            PhotonNetwork.CreateRoom(roomNameInput.text);
            // TODO MOVE AWAAY THE MENU MANAGER TOGGLE MENU CALL SOMEWHERE ELSE THAT MANAGES UI 
            MenuManager.Instance.ToggleMenu("loading");
        }

        public override void OnJoinedRoom()
        {
            MenuManager.Instance.ToggleMenu("room");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            
        }
    }
}
