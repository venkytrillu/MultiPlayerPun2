namespace Menus.Interfaces
{
    public interface IPlayerController
    {
        void Jump();
        void Move();
        void Look();
        void SetGroundState(GroundState groundState);
    }
}