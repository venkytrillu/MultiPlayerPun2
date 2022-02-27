using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICreateRoom : MenuPanel, IUIRoom
{
    [SerializeField] private TextMeshProUGUI _messagetxt; 
    
    [SerializeField] private TMP_InputField _inputFieldCreateRoom; 
    
    [SerializeField] private Button _createRoomBtn;
   
    private void Start()
    {
        _createRoomBtn.onClick.AddListener(handleCreateRoom);
    }

    private void handleCreateRoom()
    {
        PhotonManager.Instance.CreateRoom(_inputFieldCreateRoom.text);
    }

    public void SetName(string value)
    {
        _messagetxt.text = value;
    }
}