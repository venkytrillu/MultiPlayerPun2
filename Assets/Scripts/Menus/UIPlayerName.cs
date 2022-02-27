using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerName : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _roomNameTxt;
    [SerializeField] private Button _roomBtn;
    private Player _player = null;

    public void Setup(Player player)
    {
        _player = player;
        _roomNameTxt.text = player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (otherPlayer == _player)
        {
            PlayerLeftRoom();
        }
    }

    public override void OnLeftRoom()
    {
        PlayerLeftRoom();
    }

    public void PlayerLeftRoom()
    {
        Destroy(gameObject);
    }
}