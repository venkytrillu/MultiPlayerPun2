using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GenericSingletonClass<InputManager>, IInputManager
{
    public bool IsJump => Input.GetKeyDown(KeyCode.Space);
    public bool IsSprint => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    public float GetAxisHorizontal => Input.GetAxis("Horizontal");
    public float GetAxiVertical =>  Input.GetAxis("Vertical");
    public float GetAxisMouseX =>  Input.GetAxis("Mouse X");
    public float GetAxisMouseY =>  Input.GetAxis("Mouse Y");
}
