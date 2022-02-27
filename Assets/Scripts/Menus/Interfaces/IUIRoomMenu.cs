using System.Collections.Generic;
using Photon.Realtime;

public interface IUIRoomMenu
{

    void SetStartButtonState(bool state);
    void CreatePlayer(Player player);
    List<UIPlayerName> GetPlayersList();
}