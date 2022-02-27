using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MenuType
{
    LoadingMenu,
    MainMenu,
    CreateRoomMenu,
    RoomMenu,
    ErrorMenu,
    FindRoomMenu
}

public enum GroundState
{
    OnGround,
    OnAir
}

public static class Helper
{
    public static string PlayerManager = "PlayerManager";
    public static string PhotonPrefabs = "PhotonPrefabs";
    public static string PlayerController = "PlayerController";
    public static string Ground = "Ground";
}
