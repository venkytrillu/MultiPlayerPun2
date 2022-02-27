using System.Collections.Generic;
using Photon.Realtime;

public interface IUIRoomMenu
{
    void CreatePlayer(Player player);
    List<UIPlayerName> GetPlayersList();
}