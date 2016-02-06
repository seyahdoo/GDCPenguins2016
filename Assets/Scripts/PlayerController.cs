using UnityEngine;
using System.Collections;

using Globals;

public class PlayerController : MonoBehaviour
{


    //private CharacterMotor _motor;
    //private CharacterController _controller;
    //private Transform _playerTransform;


    public Vector3 MoveDir;
    public Vector2 LookDir;

    void Awake()
    {

        //_playerTransform = transform;
        //_motor = GetComponent<CharacterMotor>();
        //_controller = GetComponent<CharacterController>();

    }

    void Update()
    {

        #region Calculate MoveDir
        MoveDir.x = Input.GetAxis(PlayerInput.Horizontal);
        MoveDir.y = 0f;
        MoveDir.z = Input.GetAxis(PlayerInput.Vertical);

        //normalize move dir if not normal!?
        if (MoveDir.magnitude > 1) MoveDir = MoveDir.normalized;

        //Move Direction is calculated here

        //moveDir

        //send moveDir
        #endregion

        #region Jump Input
        //send jump input 

        // Input.GetButtonDown(PlayerInput.Jump);
        #endregion

        #region Calculate LookDir



        #endregion

    }



}
