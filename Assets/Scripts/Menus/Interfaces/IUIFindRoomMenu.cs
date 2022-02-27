using System.Collections.Generic;
using Photon.Realtime;

public interface IUIFindRoomMenu
{
    void Setup(List<RoomInfo> roomList);
    
    void DestroyRoomsListNames(List<UIRoomNameBtn> roomNameBtns);
}