using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomNameBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _roomNameTxt;
    [SerializeField] private Button _roomBtn;

    private RoomInfo _roomInfo = null;
    private void Start()
    {
        _roomBtn.onClick.AddListener(handleRoomBtnClick);
    }

    public void Setup(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        _roomNameTxt.text = roomInfo.Name;
        
    }
    
    private void handleRoomBtnClick()
    {
        PhotonManager.Instance.JoinRoom(_roomInfo);
    }

    
}
