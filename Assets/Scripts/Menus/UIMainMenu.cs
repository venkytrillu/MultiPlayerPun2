using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MenuPanel
{
    [SerializeField] private Button _findRoomBtn;
    [SerializeField] private Button _createRoomBtn;
    [SerializeField] private Button _quitBtn;
    private void Start()
    {
        _findRoomBtn.onClick.AddListener(handleFindRoom);
        _createRoomBtn.onClick.AddListener(handleCreateRoomClick);
        _quitBtn.onClick.AddListener(handleQuitClick);
    }

    private void handleFindRoom()
    {
        UIMenuManager.Instance.OpenMenu(MenuType.FindRoomMenu);
    }
    
    private void handleCreateRoomClick()
    {

    }
    
    private void handleQuitClick()
    {

    }
}