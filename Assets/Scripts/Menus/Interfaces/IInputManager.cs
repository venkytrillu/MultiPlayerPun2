public interface IInputManager
{
    bool IsJump { get; }
    bool IsSprint { get; }
    bool IsSingleShoot { get; }
    bool IsRifleShoot { get; }
    float GetAxisHorizontal { get; }
    float GetAxiVertical { get; }
    float GetAxisMouseX { get; }
    float GetAxisMouseY { get; }
    float GetAxisMouseScrollWheel { get; }
}