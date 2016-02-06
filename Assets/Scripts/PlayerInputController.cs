using UnityEngine;
using System.Collections;

using Globals;

public class PlayerInputController : MonoBehaviour
{
    
    public Vector3 MoveDir;
    public Vector2 LookDir;

    private Vector2 MouseCordNow;
    private Vector2 MouseCordLast;
    public Vector2 MouseDelta;

    
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        CalculateMoveDir();

        JumpInput();

        CalculateLookDir();

    }

    private void CalculateMoveDir()
    {
        MoveDir.x = Input.GetAxis(PlayerInput.Horizontal);
        MoveDir.y = 0f;
        MoveDir.z = Input.GetAxis(PlayerInput.Vertical);

        //normalize move dir if not normal!?
        if (MoveDir.magnitude > 1) MoveDir = MoveDir.normalized;
        

        //Move Direction is calculated here

        //moveDir

        //send moveDir
    }

    private void JumpInput()
    {
        //send jump input 

        // Input.GetButtonDown(PlayerInput.Jump);
    }

    private void CalculateLookDir()
    {
        MouseCordNow = Input.mousePosition;

        MouseDelta = MouseCordNow - MouseCordLast;


        MouseCordLast = MouseCordNow;
    }
}
