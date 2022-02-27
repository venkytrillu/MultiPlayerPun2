using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFindRoomMenu : MenuPanel, IUIRoom, IUIFindRoomMenu
{
    [SerializeField] private TextMeshProUGUI _titleNameTxt;
    [SerializeField] private GameObject _roomBtnContainer;
    [SerializeField] private GameObject _roomBtnPrefab;
    [SerializeField] private Button _backoomBtn;

    [SerializeField] private List<UIRoomNameBtn> roomNameBtns = new List<UIRoomNameBtn>();
    private HashSet<RoomInfo> _roomLists = new HashSet<RoomInfo>();
    private void Start()
    {
        _backoomBtn.onClick.AddListener(handleBackToMainMenu);
    }

    public void Setup(List<RoomInfo> roomList)
    {
        //Destroy old rooms list
        DestroyRoomsListNames(roomNameBtns);
        roomList.ForEach(x=>_roomLists.Add(x));
        //Create new Rooms list
        foreach (var roomInfo in _roomLists)
        {
            var roomBtn = Instantiate(_roomBtnPrefab, _roomBtnContainer.transform);
           var roomNameBtn =  roomBtn.GetComponent<UIRoomNameBtn>();
           roomNameBtn.Setup(roomInfo);
           roomNameBtns.Add(roomNameBtn);
        }
        
    }

    public void DestroyRoomsListNames(List<UIRoomNameBtn> roomNameBtns)
    {
        if (roomNameBtns.Count > 0)
        {
            roomNameBtns.ForEach(x => Destroy(x.gameObject));
            roomNameBtns.Clear();
        }
    }

    private void handleBackToMainMenu()
    {
        UIMenuManager.Instance.OpenMenu(MenuType.MainMenu);
    }


    public void SetName(string value)
    {
    }
}