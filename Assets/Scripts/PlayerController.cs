using UnityEngine;
using System.Collections;

using Globals;

[RequireComponent(typeof(CharacterMotor))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {



    private CharacterMotor _motor;
    private CharacterController _controller;

    private Transform _playerTransform;

    public Vector3 moveDir;

    void Awake()
    {

        _playerTransform = transform;
        _motor = GetComponent<CharacterMotor>();
        _controller = GetComponent<CharacterController>();

        //force motor to be controllable
        if (!_motor.canControl)
        {
            _motor.canControl = true;
        }

    }

    void Update()
    {


        moveDir.x = Input.GetAxis(PlayerInput.Horizontal);
        moveDir.y = 0f;
        moveDir.z = Input.GetAxis(PlayerInput.Vertical);

        if (moveDir.magnitude > 1) moveDir = moveDir.normalized;

        _motor.inputMoveDirection = moveDir;

        _motor.inputJump = Input.GetButtonDown(PlayerInput.Jump);

        
    }


	
}
