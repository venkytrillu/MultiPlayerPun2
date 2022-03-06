using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MenuPanel
{
    [SerializeField] private Button _findRoomBtn;
    [SerializeField] private Button _createRoomBtn;
    [SerializeField] private Button _quitBtn;
    [SerializeField] private TMP_InputField _playerInputField;
    public event Action<string> OnPlayerNameChanged = null;
    private void Start()
    {
        _findRoomBtn.onClick.AddListener(handleFindRoom);
        _createRoomBtn.onClick.AddListener(handleCreateRoomClick);
        _quitBtn.onClick.AddListener(handleQuitClick);
        _playerInputField.onValueChanged.AddListener(handlePlayerNameChanged);
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
    
    private void handlePlayerNameChanged(string name)
    {
        OnPlayerNameChanged?.Invoke(name);
    }
}