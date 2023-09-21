using System.Collections.Generic;
using Debugging;
using Photon.Pun;
using Photon.Realtime;
using UI;
using UnityEngine;
using TMPro;

namespace Networking
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        
        public static Launcher Instance { get; private set; }
        
        [SerializeField] private TMP_InputField roomNameInput;
        [SerializeField] private TMP_Text roomNameText;
        
        [SerializeField] private Transform roomListContent;
        [SerializeField] private GameObject roomListItemPrefab;
        [SerializeField] private Transform playerListContent;
        [SerializeField] private GameObject playerListItemPrefab;

        private void Awake()
        {
            if (Instance != null && Instance != this) 
                Destroy(this); 
            else 
                Instance = this; 
        }
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }   
        public override void OnConnectedToMaster()
        {
            MenuManager.Instance.ToggleMenu("title");
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            CustomLogger.Log("Joined lobby");
            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString();
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
            
            roomNameText.text = PhotonNetwork.CurrentRoom.Name;
            Player[] playerList = PhotonNetwork.PlayerList;
      
            foreach (var player in playerList)
            {
                Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().Setup(player);
            }
            
            MenuManager.Instance.ToggleMenu("room");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            CustomLogger.Log("Joined lobby", true);
        }

        public void JoinRoom(RoomInfo info)
        {
            PhotonNetwork.JoinRoom(info.Name);
            MenuManager.Instance.ToggleMenu("loading");
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
            
        }

        public override void OnLeftRoom()
        {
            MenuManager.Instance.ToggleMenu("title");
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            foreach (Transform roomItem in roomListContent)
            {
                Destroy(roomItem.gameObject);
            }
            foreach (RoomInfo roomItemInfo in roomList)
            {
                Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().Setup(roomItemInfo);
            }
        }

        
        public override void OnPlayerEnteredRoom(Player player)
        {
            CustomLogger.Log($"{player.NickName} entered");
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().Setup(player);
        }
    }
}
