using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour
{

    public PlayerInputController PlayerIC;
    private Rigidbody _rigidbody;
    public float Torque;

    private bool _ready;

	// Use this for initialization
	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	    StartCoroutine(ReadyAfterSecs(2f));
	}
	
	// Update is called once per frame
	void Update () {
	    if (!_ready)
	    {
	        return;
	    }
        Vector3 torque = transform.up * Torque * -PlayerIC.MouseDelta.x;
	    Vector3 t2 = transform.right*Torque*PlayerIC.MouseDelta.y;
	    torque = torque + t2;
	    _rigidbody.AddRelativeTorque(torque,ForceMode.Acceleration);

	}

    private IEnumerator ReadyAfterSecs(float s)
    {
        yield return new WaitForSeconds(s);
        _ready = true;
    }

    //private IEnumerator FSM()
    //{
    //    //PlayerIC.LookDir;
    //    //PlayerIC.MouseDelta;
    //    //PlayerIC.MoveDir
    //
    //    yield return new WaitForSeconds(0.26f);
    //}
}
