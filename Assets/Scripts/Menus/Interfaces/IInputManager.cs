public interface IInputManager
{
    bool IsJump { get; }
    bool IsSprint { get; }
    float GetAxisHorizontal { get; }
    float GetAxiVertical { get; }
    float GetAxisMouseX { get; }
    float GetAxisMouseY { get; }
}