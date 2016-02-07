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
    public Vector3 MoveDelta;

    private Vector3 _lastPos;

    public Vector2 ScrollAxis;

    public float Mouse_Sensivity = 30;

    void Update()
    {

        MoveDelta = transform.position - _lastPos;

        _lastPos = transform.position;

        ScrollAxis = Input.mouseScrollDelta;

        CursorLocking();

        CalculateMoveDir();

        CalculateLookDir();

    }

    private void CursorLocking()
    {

        if (Input.GetButtonDown(PlayerInput.CameraLock))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetButtonDown(PlayerInput.CameraUnlock))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; /// TODO maybe .Confined
        }

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


    private void CalculateLookDir()
    {
        MouseDelta = new Vector2(Input.GetAxis(PlayerInput.MouseX), Input.GetAxis(PlayerInput.MouseY)) * Mouse_Sensivity;

        //Input.GetAxis(PlayerInput.MouseX);
        //Input.GetAxis(PlayerInput.MouseY);
        //MouseCordNow = Input.mousePosition;
        //MouseDelta = MouseCordNow - MouseCordLast;
        //MouseCordLast = MouseCordNow;
    }
}
