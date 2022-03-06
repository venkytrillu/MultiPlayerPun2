using Photon.Pun;

namespace Menus.Interfaces
{
    public interface IPlayerManager
    {
        PhotonView PhotonView { get; }
        void CreatePlayerController();
        void Died();
    }
}