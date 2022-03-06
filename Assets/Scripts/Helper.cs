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

public enum GunType
{
    Rifle,
    Pistol
}

public static class Helper
{
    public static float MaxHealth = 100f;
    public static string PlayerManager = "PlayerManager";
    public static string PhotonPrefabs = "PhotonPrefabs";
    public static string PlayerController = "PlayerController";
    public static string Ground = "Ground";
    public static string ItemIndex = "ItemIndex";
}
