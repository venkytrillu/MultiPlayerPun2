using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager Instance { get; private set; }
    UIMainMenu mainMenu = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        mainMenu = (UIMainMenu) UIMenuManager.Instance.GetMenu(MenuType.MainMenu);
        bind();
    }

    private void bind()
    {
        unbind();
        mainMenu.OnPlayerNameChanged += setPlayerName;
    }

    private void unbind()
    {
        mainMenu.OnPlayerNameChanged -= setPlayerName;
    }
    
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnConnectedToMaster()
    {
        //Debug.Log("On Connected To Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        //Debug.Log("Joined Lobby");
        UIMenuManager.Instance.OpenMenu(MenuType.MainMenu);
    }

    public void CreateRoom(string roomName)
    {
        if (string.IsNullOrWhiteSpace(roomName))
        {
            return;
        }

        PhotonNetwork.CreateRoom(roomName);
        UIMenuManager.Instance.OpenMenu(MenuType.LoadingMenu);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        UIMenuManager.Instance.OpenMenu(MenuType.CreateRoomMenu);
    }

    public override void OnJoinedRoom()
    {
        if(string.IsNullOrWhiteSpace(PhotonNetwork.NickName))
        {
            PhotonNetwork.NickName = "Player - " + Random.Range(0, int.MaxValue).ToString("00000");
        }
        
        UIMenuManager.Instance.OpenMenu(MenuType.RoomMenu);

        var playerList = PhotonNetwork.PlayerList;
        var roomMenu = (IUIRoomMenu) UIMenuManager.Instance.GetMenu(MenuType.RoomMenu);
        foreach (var player in playerList)
        {
            roomMenu.CreatePlayer(player);
        }
        
    }

    private void setPlayerName(string playerName)
    {
        PhotonNetwork.NickName = playerName;
    }

    public string GetCurrentRoomName()
    {
        var name = PhotonNetwork.CurrentRoom.Name;
        return !string.IsNullOrWhiteSpace(name) ? name : string.Empty;
    }

    public void JoinRoom(RoomInfo roomInfo)
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
        UIMenuManager.Instance.OpenMenu(MenuType.LoadingMenu);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        UIMenuManager.Instance.OpenMenu(MenuType.LoadingMenu);
    }

    public override void OnLeftRoom()
    {
        UIMenuManager.Instance.OpenMenu(MenuType.MainMenu);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        IUIFindRoomMenu findRoomMenu = (IUIFindRoomMenu) UIMenuManager.Instance.GetMenu(MenuType.FindRoomMenu);
        if (findRoomMenu != null)
        {
            findRoomMenu.Setup(roomList);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        var roomMenu = UIMenuManager.Instance.GetMenu(MenuType.RoomMenu) as IUIRoomMenu;
        roomMenu.CreatePlayer(newPlayer);
    }

    public string LocalPlayerID()
    {
        return PhotonNetwork.LocalPlayer.UserId;
    }

    public bool IsHost()
    {
        return PhotonNetwork.IsMasterClient;
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        var roomMenu = UIMenuManager.Instance.GetMenu(MenuType.RoomMenu) as IUIRoomMenu;
        if (roomMenu != null)
        {
            roomMenu.SetStartButtonState(IsHost());
        }
    }
}